using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeerSound : MonoBehaviour
{
    public AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        hitSound.Play();
    }
}
