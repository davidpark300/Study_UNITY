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
    private float tempTime = 0.0f;
    private float stopBallTime = 3.0f;
    private bool stopFlag = false;
    // Update is called once per frame
    void Update()
    {
        tempTime = Time.time + fireInterval;
        if (!stopFlag)
        {
            if (Time.time > nextBallTime)
            {
                nextBallTime = tempTime;
                //nextBallTime = Time.time + fireInterval;
                Vector3 position = new Vector3(Random.Range(rangeMinX, rangeMaxX), startHeight, Random.Range(rangeMinZ, rangeMaxZ));
                Instantiate(ball, position, Quaternion.identity);
                if (Time.time > 3.0f)
                {
                    stopFlag = true;
                }
            }
        }
        else
        {
            StartCoroutine(stopBall());
        }
    }

    private IEnumerator stopBall()
    {
        yield return new WaitForSeconds(stopBallTime);
        stopFlag = false;
    }
}
