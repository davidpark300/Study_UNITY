using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGesture : MonoBehaviour
{
    public bool isFacingDown = false;
    public bool isMovingDown = false;
    private float sweepRate = 100.0f;
    private float previousCameraAngle;
    void Start()
    {
        previousCameraAngle = CameraAngleFrontGround();
    }
    void Update()
    {
        isFacingDown = DetectFacingDown();
        isMovingDown = DetectMovingDown();
    }
    private bool DetectFacingDown()
    {
        return (CameraAngleFrontGround() < 60.0f);
    }
    private bool DetectMovingDown()
    {
        float angle = CameraAngleFrontGround();
        float deltaAngle = previousCameraAngle - angle;
        float rate = deltaAngle / Time.deltaTime;
        previousCameraAngle = angle;
        return (rate >= sweepRate);
    }
    private float CameraAngleFrontGround()
    {
        return Vector3.Angle(Vector3.down,
       Camera.main.transform.rotation * Vector3.forward);
    }
}
