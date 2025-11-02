using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FruitFusionManager : MonoBehaviour
{
    private ScoreSubject scoreSubject;
    private GameObject fruits;
    private FruitsInfoManager fruitsInfo;
    private MousePosFruit mousePosFruit;

    private int grade;
    public int fusion = 0;
    public bool fusioned = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 같은 등급의 과일이 합쳐졌을 때
        if (!fusioned && collision.gameObject.tag == "Fruit" && !mousePosFruit.isMoving && 
            !collision.gameObject.GetComponent<MousePosFruit>().isMoving && this.grade == collision.gameObject.GetComponent<FruitInfomation>().grade)
        {
            this.fusioned = true;
            collision.gameObject.GetComponent<FruitFusionManager>().fusioned = true;
            while (this.fusion == collision.gameObject.GetComponent<FruitFusionManager>().fusion)
            { // 충돌한 양쪽 과일 중 한 쪽에서만 합쳐지는 처리를 실행하도록
                fusion = Random.Range(0, 2);
            }

            if (fusion == 1)
            {
                scoreSubject.IncreaseScore(this.GetComponent<FruitInfomation>().point); // 점수 증가

                GameObject newFruit = null;
                if (grade >= 10) newFruit = Instantiate(fruitsInfo.FruitsPrefab[0]); // 수박끼리 합쳐지면 체리로
                else             newFruit = Instantiate(fruitsInfo.FruitsPrefab[this.grade + 1]); // 한 단계 위의 과일로 합짐
                newFruit.GetComponent<CircleCollider2D>().enabled = true;
                newFruit.GetComponent<MousePosFruit>().isMoving = false;
                newFruit.GetComponent<MousePosFruit>().gameOverTrigger = true;
                newFruit.transform.position = new Vector3((this.transform.position.x + 
                    collision.transform.position.x) / 2.0f, (this.transform.position.y + collision.transform.position.y) / 2.0f, 0.1f);
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    void Start()
    {
        scoreSubject = GameObject.FindObjectOfType<ScoreManager>().scoreSubject;

        this.grade = GetComponent<FruitInfomation>().grade;
        fruits = GameObject.Find("Fruits");
        fruitsInfo = fruits.GetComponent<FruitsInfoManager>();
        mousePosFruit = GetComponent<MousePosFruit>();
    }
}
