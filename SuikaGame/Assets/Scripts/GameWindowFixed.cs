using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWindowFixed : MonoBehaviour
{
    public void SetResolution()
    {
        int setWidth = 1920;
        int setHeight = 1080;
        Screen.SetResolution(setWidth, setHeight, true);
    }

    void Start()
    {
        SetResolution();
    }
}
