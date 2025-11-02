using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private InterfaceCommand restartCommand;
    private InterfaceCommand exitCommand;
    private InterfaceCommand rankResetCommand;
    private InterfaceCommand toTitleCommand;

    private void InputCommand()
    {
        if (Input.GetKeyDown(KeyCode.R))
            restartCommand.Execute();
        else if (Input.GetKeyDown(KeyCode.Escape))
            exitCommand.Execute();
        else if (Input.GetKeyDown(KeyCode.E))
            rankResetCommand.Execute();
        else if (Input.GetKeyDown(KeyCode.T))
            toTitleCommand.Execute();
    }

    void Start()
    {
        restartCommand = new RestartCommand();
        exitCommand = new ExitCommand();
        rankResetCommand = new RankResetCommand();
        toTitleCommand = new ToTitleCommand();
    }

    void Update()
    {
        InputCommand();
    }
}
