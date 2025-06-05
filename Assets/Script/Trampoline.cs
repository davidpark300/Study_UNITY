using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 1000.0f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * bounceForce);
        }
        else
        {
            MoveMyEye locomotor = other.GetComponent<MoveMyEye>();
            if (locomotor != null)
            {
                locomotor.bounceForce = bounceForce;
            }
        }

    }

}
