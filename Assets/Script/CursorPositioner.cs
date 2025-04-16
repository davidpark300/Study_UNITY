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
        Transform camera = Camera.main.transform;   // ī�޶� ��ġ
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);  // ī�޶� ��ġ���� ī�޶� �� ������� Ray
        Debug.Log(camera.position + "," + camera.rotation);
        RaycastHit hit; // Ray�� �浹������ ����
        if (Physics.Raycast(ray, out hit))  // Ray�� �浹�ߴ��� ����
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
