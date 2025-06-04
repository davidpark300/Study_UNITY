using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpot : MonoBehaviour
{
    public CollectArtwork collectArtwork;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        collectArtwork.isEnableCollect();
    }

    private void OnTriggerExit(Collider other)
    {
        collectArtwork.isDisableCollect();
    }
}
