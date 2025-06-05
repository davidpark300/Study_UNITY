using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindControl : MonoBehaviour
{
    public ParticleSystem ps;
    public bool isPlayed;
    public WindControl windControl;
    // Start is called before the first frame update
    void Start()
    {
        isPlayed = false;
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MoveMyEye eye = other.GetComponent<MoveMyEye>();
            setIsPlayed();
            windControl.setIsPlayed();
            if (isPlayed)
            {
                Debug.Log("바람 개방");
                ps.Play();
                eye.gravity = 3.0f;
            }
            else
            {
                Debug.Log("바람 차단");
                ps.Stop();
                eye.gravity = 9.8f;
            }
        }
    }

    public void setIsPlayed()
    {
        isPlayed = !isPlayed;
    }
}
