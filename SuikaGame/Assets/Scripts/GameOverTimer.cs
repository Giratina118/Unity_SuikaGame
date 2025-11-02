using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverTimer : MonoBehaviour
{
    private ScoreSubject scoreSubject;
    public ScoreManager scoreManager;
    public GameOverMediator mediator;
    public GameObject gameOverUI;

    public TMP_Text finalScore;
    public TMP_Text finalRank1Score;
    public TMP_Text finalRank2Score;
    public TMP_Text finalRank3Score;

    public float contactTime = 0.0f;
    public float gameOverCheckTime = 2.0f;
    public bool stay = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MousePosFruit>().gameOverTrigger)
        {
            contactTime = 0.0f; // 접촉 시간을 0으로 초기화
            stay = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<MousePosFruit>().gameOverTrigger)
            stay = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MousePosFruit>().gameOverTrigger)
            contactTime = 0.0f; // 접촉 시간을 0으로 초기화
        stay = false;
    }


    void Start()
    {
        scoreSubject = scoreManager.scoreSubject;
    }

    void Update()
    {
        if (stay)
            contactTime += Time.deltaTime; // 물체가 접촉하는 동안 시간을 누적

        if (mediator.gameOver)
            return; // 게임 오버 상태일 때 아무 작업도 하지 않음

        if (contactTime >= gameOverCheckTime) // 물체가 2초 동안 접촉하면 트리거 작동
        {
            mediator.SetGameOverBool(true);
            scoreManager.ScoreSave();
            gameOverUI.SetActive(true);
            finalScore.text = scoreSubject.Score.ToString();

            finalRank1Score.text = PlayerPrefs.GetInt("1").ToString();
            finalRank2Score.text = PlayerPrefs.GetInt("2").ToString();
            finalRank3Score.text = PlayerPrefs.GetInt("3").ToString();
        }
    }
}
