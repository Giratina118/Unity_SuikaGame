using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameOverMediator : MonoBehaviour
{
    public bool gameOver = false;

    public void SetGameOverBool(bool gameOver)
    {
        this.gameOver = gameOver;
    }

    public bool GetGameOverBool()
    {
        return gameOver;
    }

}

