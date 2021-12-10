using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusScript : MonoBehaviour
{
    [SerializeField] private float X_ENDING_POINT;
    [SerializeField] private float SPEED;

    private Vector2 newPosition;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        newPosition = new Vector2(this.transform.position.x, this.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Environment.instance.isGameOver)
        {
            newPosition.x -= SPEED * Time.deltaTime;
            this.transform.position = newPosition;

            if (this.transform.position.x < X_ENDING_POINT)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
