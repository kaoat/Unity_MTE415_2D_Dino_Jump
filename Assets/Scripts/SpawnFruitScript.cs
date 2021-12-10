using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruitScript : MonoBehaviour
{
    [SerializeField] private float MAX_HEIGHT;
    [SerializeField] private float MIN_HEIGHT;
    [SerializeField] private float BORDER_LEFT;
    [SerializeField] private float BORDER_RIGHT;
    [SerializeField] private GameObject[] fruit;
    [SerializeField] private float INTERVAL_TIME;

    private float accumulatedTime;
    private Vector2 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        accumulatedTime = 0;
        spawnPosition = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Environment.instance.isGameOver)
        {
            accumulatedTime += Time.deltaTime;
            if (accumulatedTime > INTERVAL_TIME)
            {
                accumulatedTime = 0;
                spawnPosition.x = Environment.instance.RandomFloat(BORDER_LEFT, BORDER_RIGHT);
                spawnPosition.y = Environment.instance.RandomFloat(MIN_HEIGHT, MAX_HEIGHT);
                Instantiate(fruit[Environment.instance.RandomInt(0, fruit.Length)], spawnPosition, this.transform.rotation);
            }
        }
    }
}
