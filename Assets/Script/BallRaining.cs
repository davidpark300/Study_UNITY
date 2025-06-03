using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRaining : MonoBehaviour
{
    public GameObject ball;
    public float startHeight = 25f;
    public float fireInterval = 0.5f;

    private float nextBallTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextBallTime)
        {
            nextBallTime = Time.time + fireInterval;
            Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), startHeight, Random.Range(-60.0f, -20.0f));
            Instantiate(ball, position, Quaternion.identity);
        }
    }
}
