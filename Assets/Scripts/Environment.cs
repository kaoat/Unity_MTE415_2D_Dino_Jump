using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public static Environment instance;
    public bool isGameOver;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        isGameOver = false;
    }

    public void PauseWorld()
    {
        Time.timeScale = 0;
    }

    public void ResumeWorld()
    {
        Time.timeScale = 1;
    }

    public void StopWorld()
    {
        isGameOver = true;
    }
}
