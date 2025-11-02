using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.SceneManagement;


public interface InterfaceCommand
{
    void Execute();
}

public class RestartCommand : InterfaceCommand
{
    public void Execute()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

public class ExitCommand : InterfaceCommand
{
    public void Execute()
    {
        Application.Quit();
    }
}

public class RankResetCommand : InterfaceCommand
{
    public void Execute()
    {
        GameObject.Find("ScoreImage").GetComponent<ScoreManager>().SaveScoreReset();
    }
}

public class ToTitleCommand : InterfaceCommand
{
    public void Execute()
    {
        SceneManager.LoadScene("TitleScene");
    }
}