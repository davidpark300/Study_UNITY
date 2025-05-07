using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyWalk : MonoBehaviour
{
    private HeadLookWalk lookWalk;
    private AudioSource footsteps;
    private Transform head;
    private Transform body;

    // Start is called before the first frame update
    void Start()
    {
        lookWalk = GetComponent<HeadLookWalk>();
        footsteps = GetComponent<AudioSource>();
        head = Camera.main.transform;
        body = transform.Find("MeBody");
    }

    // Update is called once per frame
    void Update()
    {
        if (lookWalk.isWalking)
        {
            body.transform.rotation = Quaternion.Euler(new Vector3(0.0f, head.transform.eulerAngles.y, 0.0f));
            // Quaternion : 회전 축을 주고 걔를 기준으로 얼마나 회전할 것인지, 그냥 Quaternion만 쓰면 됨, 현업에서 안씀
            // EulerAngles : 현업에서 안씀, 서로 호환은 됨
            if (!footsteps.isPlaying)
            {
                footsteps.Play();
            }
        }
        else
        {
            footsteps.Stop();
        }
    }
}
