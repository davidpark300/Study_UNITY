using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRaining : MonoBehaviour
{
    public GameObject ball;
    public float startHeight = 25f;
    public float fireInterval = 0.5f;
    public float rangeMinX = -10.0f;
    public float rangeMaxX = 10.0f;
    public float rangeMinZ = -10.0f;
    public float rangeMaxZ = 10.0f;
    private float nextBallTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextBallTime)
        {
            nextBallTime = Time.time + fireInterval;
            Vector3 position = new Vector3(Random.Range(rangeMinX, rangeMaxX), startHeight, Random.Range(rangeMinZ, rangeMaxZ));
            Instantiate(ball, position, Quaternion.identity);
        }
    }
}
