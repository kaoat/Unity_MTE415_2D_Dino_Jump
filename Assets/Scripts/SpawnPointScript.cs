using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class SpawnPointScript : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;

    [SerializeField] private float INTERVAL_TIME;

    private float accumulatedDeltaTime;
    private Random randomGenerator;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        accumulatedDeltaTime = 0;
        randomGenerator = new Random(DateTime.Now.Millisecond);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Environment.instance.isGameOver)
        {
            accumulatedDeltaTime += Time.deltaTime;

            if (accumulatedDeltaTime > INTERVAL_TIME)
            {
                accumulatedDeltaTime = 0;

                Instantiate(enemy[randomGenerator.Next(0, enemy.Length)], this.transform.position, this.transform.rotation);
            }
        }
    }
}
