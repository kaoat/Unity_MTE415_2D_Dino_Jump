using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceScript : MonoBehaviour
{
    [SerializeField] private Text scoreTextObject;
    [SerializeField] private Text timeTextObject;

    private int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
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
        }
    }
}
