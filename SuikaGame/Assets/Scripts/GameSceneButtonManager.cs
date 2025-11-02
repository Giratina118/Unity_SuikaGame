using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneButtonManager : MonoBehaviour
{
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickTitleSceneButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
