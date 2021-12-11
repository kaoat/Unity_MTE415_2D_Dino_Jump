using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private string playerTagName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTagName))
        {
            Environment.instance.AddScore(score);
            Environment.instance.playerAudioScript.AudioPickItem();
            Destroy(this.gameObject);
        }
    }
}
