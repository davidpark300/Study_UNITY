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
            // Quaternion : ȸ�� ���� �ְ� �¸� �������� �󸶳� ȸ���� ������, �׳� Quaternion�� ���� ��, �������� �Ⱦ�
            // EulerAngles : �������� �Ⱦ�, ���� ȣȯ�� ��
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
