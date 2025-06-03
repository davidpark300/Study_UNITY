using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RotatingFloorController : MonoBehaviour
{
    public GameObject[] rotatingFloor;
    public float firstRotateValue = 1f;

    private bool isRotatedToMax;

    private void Update()
    {
        rotating();
        
    }

    private void rotating()
    {
        for (int i = 0; i < rotatingFloor.Length; i++)
        {
            if (i == 0)
            {
                float angle = Mathf.Sin(Time.time * firstRotateValue) * 60;

                // Quaternion을 사용하여 Z축 회전 적용
                rotatingFloor[i].transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            if (i == 1)
            {
                float addition = 0.5f;
                float angle = rotatingFloor[i].transform.eulerAngles.z;
                angle += addition;
                rotatingFloor[i].transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            if (i == 2)
            {

            }
        }

    }
}
