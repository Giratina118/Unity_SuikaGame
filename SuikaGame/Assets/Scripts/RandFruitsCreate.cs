using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandFruitsCreate : MonoBehaviour
{
    private FruitCreationStateManager stateManager;
    private GameObject nextFruit = null;
    public GameOverMediator mediator;
    public FruitsInfoManager fruitsInfo;
    public float fruitCreationInterval = 0.5f;
    public bool fruitEnabled = true;
    public int randCreate = 0;


    void CreateNextFruit() // 다음 과일 생성
    {
        stateManager.SetRandomCreateValue(this);
        GameObject newFruit = Instantiate(fruitsInfo.FruitsPrefab[randCreate]);
        newFruit.GetComponent<Rigidbody2D>().gravityScale = 0;
        nextFruit = newFruit;
        nextFruit.transform.position = new Vector3(6.0f, 2.5f, 1.0f);
    }

    void Start()
    {
        stateManager = new FruitCreationStateManager();
        stateManager.SetState(new LowScoreState());
        CreateNextFruit();
    }

    void Update()
    {
        if (fruitEnabled && Input.GetMouseButtonDown(0) && !mediator.GetGameOverBool())
            StartCoroutine(CreateRandomFruit());
    }

    IEnumerator CreateRandomFruit()
    {
        fruitEnabled = false;
        yield return new WaitForSeconds(fruitCreationInterval);
        nextFruit.GetComponent<MousePosFruit>().isMoving = true;
        CreateNextFruit();
        fruitEnabled = true;
    }
}

public interface IFruitCreationState
{
    void SetRandomCreateValue(RandFruitsCreate randFruitsCreate);
}

// 구체적인 상태 클래스
public class LowScoreState : IFruitCreationState // 낮은 점수 상태
{
    public void SetRandomCreateValue(RandFruitsCreate randFruitsCreate)
    {
        int rand = Random.Range(0, 20);
        if (rand < 5)       randFruitsCreate.randCreate = 0;
        else if (rand < 10) randFruitsCreate.randCreate = 1;
        else if (rand < 15) randFruitsCreate.randCreate = 2;
        else if (rand < 18) randFruitsCreate.randCreate = 3;
        else                randFruitsCreate.randCreate = 4;
    }
}

public class MiddleScoreState : IFruitCreationState // 중간 점수 상태
{
    public void SetRandomCreateValue(RandFruitsCreate randFruitsCreate)
    {
        int rand = Random.Range(0, 20);
        if (rand < 4)       randFruitsCreate.randCreate = 0;
        else if (rand < 8)  randFruitsCreate.randCreate = 1;
        else if (rand < 12) randFruitsCreate.randCreate = 2;
        else if (rand < 16) randFruitsCreate.randCreate = 3;
        else                randFruitsCreate.randCreate = 4;
    }
}

public class HighScoreState : IFruitCreationState // 높은 점수 상태
{
    public void SetRandomCreateValue(RandFruitsCreate randFruitsCreate)
    {
        int rand = Random.Range(0, 20);
        if (rand < 2)       randFruitsCreate.randCreate = 0;
        else if (rand < 5)  randFruitsCreate.randCreate = 1;
        else if (rand < 10) randFruitsCreate.randCreate = 2;
        else if (rand < 15) randFruitsCreate.randCreate = 3;
        else                randFruitsCreate.randCreate = 4;
    }
}

// 상태 관리 클래스
public class FruitCreationStateManager
{
    private IFruitCreationState currentState;

    public void SetState(IFruitCreationState newState)
    {
        currentState = newState;
    }

    public void UpdateState(int score) // 상태 업데이트
    {
        if (score < 500)       SetState(new LowScoreState());
        else if (score < 1500) SetState(new MiddleScoreState());
        else                   SetState(new HighScoreState());
    }

    public void SetRandomCreateValue(RandFruitsCreate randFruitsCreate)
    {
        if (currentState != null) // 상태에 따라 과일 생성 확률 다르게
            currentState.SetRandomCreateValue(randFruitsCreate);
    }
}