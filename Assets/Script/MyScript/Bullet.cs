using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Camera.main.transform.forward * speed;
    }

}
