using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGame : MonoBehaviour
{
    public GameObject ball;
    public float startHeight = 10f;
    public float fireInterval = 5f;

    private float nextBallTime = 0.0f;
    private GameObject activeBall;
    private Transform head;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        head = Camera.main.transform;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextBallTime)
        {
            nextBallTime = Time.time + fireInterval;
            audio.Play();
            Vector3 position = new Vector3(head.position.x, startHeight, head.position.z + 0.2f);
            activeBall = Instantiate(ball, position, Quaternion.identity) as GameObject;
        }
    }
}
