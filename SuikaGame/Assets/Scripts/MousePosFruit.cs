using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MousePosFruit : MonoBehaviour
{
    GameOverMediator mediator;

    private Camera mainCamera;
    public bool isMoving = false;
    public bool gameOverTrigger = false;
    public float gameOverTriggerInterval = 0.5f;


    void Start()
    {
        GameObject mediatorGameObject = GameObject.Find("GameOverMediatorManager");
        mediator = mediatorGameObject.GetComponent<GameOverMediator>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isMoving && !mediator.GetGameOverBool())
        {
            Vector3 mousePositionScreen = Input.mousePosition;
            Vector3 mousePositionWorld = mainCamera.ScreenToWorldPoint(new Vector3(mousePositionScreen.x, 0.0f, 1.0f));
            mousePositionWorld.y = 3.8f;

            if (mousePositionWorld.x > this.GetComponent<FruitInfomation>().maxDistance)
                mousePositionWorld.x = this.GetComponent<FruitInfomation>().maxDistance;
            else if (mousePositionWorld.x < -this.GetComponent<FruitInfomation>().maxDistance)
                mousePositionWorld.x = -this.GetComponent<FruitInfomation>().maxDistance;

            this.transform.position = mousePositionWorld;

            if (Input.GetMouseButtonDown(0))
            {
                isMoving = false;
                this.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
                this.GetComponent<CircleCollider2D>().enabled = true;

                StartCoroutine(GameOverTriggerTime());
            }
        }
    }

    IEnumerator GameOverTriggerTime()
    {
        yield return new WaitForSeconds(gameOverTriggerInterval);
        gameOverTrigger = true;
    }
}
