using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityRandomGenerator = UnityEngine.Random;
using dotNetRandomGenerator = System.Random;
using UnityEngine.SceneManagement;

public class Environment : MonoBehaviour
{
    public static Environment instance;
    public bool isGameOver;
    public int playerScore;
    public float playTime;
    public bool isPause;
    public AudioSource playerAudioSource;
    public AudioSource SystemAudioSource;
    public GameObject playerObject;
    public string mainMenuSceneName;
    public string currentSceneName;

    public PlayerAudioScript playerAudioScript;

    private dotNetRandomGenerator dotNetRandomGenerator;
    private void Awake()
    {
        instance = this;
        unityRandomGenerator.InitState(DateTime.Today.Millisecond);
        dotNetRandomGenerator = new dotNetRandomGenerator(DateTime.Today.Second);
        playerAudioScript = playerObject.GetComponentInChildren<PlayerAudioScript>();
    }
    private void Start()
    {
        isGameOver = false;
        playerScore = 0;
        isPause = false;
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

    public void AddScore(int score)
    {
        playerScore += score;
    }


    public float RandomFloat(float minValue, float maxValue)
    {
        return unityRandomGenerator.Range(minValue,maxValue);
    }
    public int RandomInt(int minValue, int maxValue)
    {
        return dotNetRandomGenerator.Next(minValue,maxValue);
    }

    public void GoToMainMenu()
    {
        ResumeWorld();
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
