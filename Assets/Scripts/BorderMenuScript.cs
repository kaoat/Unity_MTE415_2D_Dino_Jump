using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderMenuScript : MonoBehaviour
{
    [SerializeField] private string logoTagName;
    [SerializeField] private Vector2 force;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(logoTagName))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
            MainMenuScript.instance.audioPlayer.PlayOneShot(MainMenuScript.instance.audioPlayer.clip);
        }
    }
}
