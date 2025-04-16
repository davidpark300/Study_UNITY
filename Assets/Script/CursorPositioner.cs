using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPositioner : MonoBehaviour
{
    private float defaultPosz;
    // Start is called before the first frame update
    void Start()
    {
        defaultPosz = transform.localPosition.z;    // 0, 0, 1
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;   // 카메라 위치
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);  // 카메라 위치부터 카메라 앞 방향까지 Ray
        Debug.Log(camera.position + "," + camera.rotation);
        RaycastHit hit; // Ray가 충돌한지에 대한
        if (Physics.Raycast(ray, out hit))  // Ray가 충돌했는지 판정
        {
            if (hit.distance <= defaultPosz)
            {
                transform.localPosition = new Vector3(0, 0, hit.distance);
            }
            else
            {
                transform.localPosition = new Vector3(0, 0, defaultPosz);
            }
        }
    }
}
