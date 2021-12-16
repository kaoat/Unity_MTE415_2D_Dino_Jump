using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MovieGameScript : MonoBehaviour
{
    [SerializeField] private GameObject uiObject;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private Text textObject;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        textObject.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)&&videoPlayer.isPlaying)||(videoPlayer.frame > 0 && !videoPlayer.isPlaying))
        {
            this.gameObject.SetActive(false);
            uiObject.SetActive(true);
        }
    }
}
