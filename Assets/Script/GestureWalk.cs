using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureWalk : MonoBehaviour
{
    private HeadLookWalk lookWalk;
    private HeadGesture gesture;
    // Start is called before the first frame update
    void Start()
    {
        lookWalk = GetComponent<HeadLookWalk>();
        gesture = GameObject.Find("GameController").GetComponent<HeadGesture>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gesture.isMovingDown)
        {
            lookWalk.isWalking = !lookWalk.isWalking;
        }
    }
}
