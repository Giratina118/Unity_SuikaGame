using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneButtonManager : MonoBehaviour
{
    public GameObject rankingBook = null;

    public void OnClickStartGameButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickRankingButton()
    {
        rankingBook.gameObject.SetActive(true);
    }

    public void OnClickExitGameButton()
    {
        Application.Quit();
    }

    public void OnClickReturnTitleButton()
    {
        rankingBook.gameObject.SetActive(false);
    }
}
