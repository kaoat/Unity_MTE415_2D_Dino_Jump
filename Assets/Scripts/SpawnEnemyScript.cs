using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnEnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;

    [SerializeField] private float INTERVAL_TIME;

    private float accumulatedDeltaTime;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        accumulatedDeltaTime = 0;
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

                Instantiate(enemy[Environment.instance.RandomInt(0,enemy.Length)], this.transform.position, this.transform.rotation);
            }
        }
    }
}
