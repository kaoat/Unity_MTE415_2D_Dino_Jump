using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovingScript : MonoBehaviour
{
    [SerializeField] private float MOVING_SPEED;
    [SerializeField] private float X_ENDING_POINT;
    [SerializeField] private float X_STARTING_POINT;

    private Vector2 newPosition;
    private bool isEnd;

    private void Awake()
    {
        newPosition = this.transform.position;
        isEnd = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newPosition.x -= MOVING_SPEED * Time.deltaTime;
        isEnd = newPosition.x < X_ENDING_POINT;

        if (isEnd)
        {
            newPosition.x = X_STARTING_POINT;
        }

        this.transform.position = newPosition;
    }
}
