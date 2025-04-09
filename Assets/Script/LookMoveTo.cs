using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMoveTo : MonoBehaviour
{
    public GameObject ground;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f);
        ray = new Ray(camera.position, camera.rotation * Vector3.forward * 100.0f); // ī�޶� ���� ���⿡ ���� ray�� ����� ���� �չ��� ����?
        hits = Physics.RaycastAll(ray); // RaycastAll�� ������ �ε��� ��� ������Ʈ ������ ���ʴ�� ������
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i]; // ������ �ε��� ������Ʈ 1�� ���� ��������
            hitObject = hit.collider.gameObject; // hit�� �ε��� ������Ʈ ��������
            if (hitObject == ground)
            {
                Debug.Log("Hit (x,y,z): " + hit.point.ToString("F2"));
                transform.position = hit.point;
            }

        }
    }
}
