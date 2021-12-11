using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceScript : MonoBehaviour
{
    [SerializeField] private Text scoreTextObject;
    [SerializeField] private Text timeTextObject;
    [SerializeField] private GameObject panelObject;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject soundPanel;
    [SerializeField] private Slider effectSoundBar;
    [SerializeField] private Slider backgroundSoundBar;

    private int currentScore;
    private bool isPause;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        backgroundSoundBar.value = Environment.instance.SystemAudioSource.volume;
        effectSoundBar.value = Environment.instance.playerAudioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Environment.instance.isGameOver)
        {
            if (currentScore != Environment.instance.playerScore)
            {
                scoreTextObject.text = $"Score : {Environment.instance.playerScore}";
            }

            timeTextObject.text = $"Time : {Environment.instance.playTime.ToString("0.00")}";

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Environment.instance.isPause = !Environment.instance.isPause;

                if (Environment.instance.isPause)
                {
                    ShowMenu();
                }
                else
                {
                    HideMenu();
                }
            }
        }
    }

    public void ShowMenu()
    {
        Environment.instance.PauseWorld();
        panelObject.SetActive(true);
    }

    public void HideMenu()
    {
        Environment.instance.ResumeWorld();
        panelObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void HideMainPanel()
    {
        mainPanel.SetActive(false);
    }

    public void ShowMainPanel()
    {
        mainPanel.SetActive(true);
    }
    
    public void HideSoundPanel()
    {
        soundPanel.SetActive(false);
    }

    public void ShowSoundPanel()
    {
        soundPanel.SetActive(true);
    }

    public void ChangeEffectVolume()
    {
        Environment.instance.playerAudioSource.volume = effectSoundBar.value;
    }

    public void ChangeBackgroundVolume()
    {
        Environment.instance.SystemAudioSource.volume = backgroundSoundBar.value;
    }
}
