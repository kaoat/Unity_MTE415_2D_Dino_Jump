using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] playerAudio;
    
    private AudioSource audioPlayer;

    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioJump()
    {
        audioPlayer.PlayOneShot(playerAudio[0]);
    }
    
    public void AudioPickItem()
    {
        audioPlayer.PlayOneShot(playerAudio[1]);
    }
}
