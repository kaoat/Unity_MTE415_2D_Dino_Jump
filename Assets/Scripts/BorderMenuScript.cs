using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderMenuScript : MonoBehaviour
{
    [SerializeField] private string logoTagName;
    [SerializeField] private Vector2 force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(logoTagName))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
            MainMenuScript.instance.audioPlayer.PlayOneShot(MainMenuScript.instance.audioPlayer.clip);
        }
    }
}
