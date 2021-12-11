using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private string gameScene;
    
    public AudioSource audioPlayer;

    public static MainMenuScript instance;

    private void Awake()
    {
        instance = this;
    }
    public void EnterGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
