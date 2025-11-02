using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public ScoreSubject scoreSubject;
    private FruitCreationStateManager stateManager = new FruitCreationStateManager();

    private List<int> scores = new List<int>();

    public TMP_Text nowScoreText;
    public TMP_Text bestScore;
    public TMP_Text rank1;
    public TMP_Text rank2;
    public TMP_Text rank3;
    public TMP_Text RanknowScore;
    public TMP_Text nowRanking;

    public bool saveScoreReset = false;

    public void ScoreSave()
    {
        int changeRank = 20;
        for (int i = 0; i < 20; i++)
        {
            if (scoreSubject.Score >= scores[i])
            {
                changeRank = i;
                break;
            }
        }
        
        if (changeRank < 20)
        {
            for (int i = 19; i > changeRank; i--)
                PlayerPrefs.SetInt((i + 1).ToString(), scores[i - 1]);
            PlayerPrefs.SetInt((changeRank + 1).ToString(), scoreSubject.Score);
        }
    }

    void ShowNowScore()
    {
        nowScoreText.text = scoreSubject.Score.ToString();
        RanknowScore.text = scoreSubject.Score.ToString();
    }

    public void ShowNowRank()
    {
        for (int i = 0; i < 20; i++)
        {
            if (scoreSubject.Score >= scores[i])
            {
                nowRanking.text = (i + 1).ToString();
                break;
            }
        }

    }

    void ShowScoreRank()
    {
        bestScore.text = scores[0].ToString();
        rank1.text = scores[0].ToString();
        rank2.text = scores[1].ToString();
        rank3.text = scores[2].ToString();
    }

    public void SaveScoreReset()
    {
        for (int i = 1; i < 21; i++)
        {
            PlayerPrefs.SetInt(i.ToString(), 0);
            scores[i - 1] = PlayerPrefs.GetInt(i.ToString());
        }
        ShowScoreRank();
        ShowNowRank();
    }

    private void UpdateScoreText(int newScore)
    {
        ShowNowScore();
        ShowScoreRank();
        ShowNowRank();
        stateManager.UpdateState(scoreSubject.Score);
    }

    void Start()
    {
        scoreSubject = new ScoreSubject();
        scoreSubject.AddScoreObserver(UpdateScoreText);

        if (saveScoreReset)
            SaveScoreReset();

        for (int i = 0; i < 20; i++)
            scores.Add(PlayerPrefs.GetInt((i + 1).ToString()));

        ShowScoreRank();
    }
}
