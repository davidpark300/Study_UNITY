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
        ray = new Ray(camera.position, camera.rotation * Vector3.forward * 100.0f); // 카메라가 보는 방향에 대한 ray를 만들기 위해 앞방향 곱셈?
        hits = Physics.RaycastAll(ray); // RaycastAll은 광선이 부딪힌 모든 오브젝트 정보를 차례대로 가져옴
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i]; // 광선과 부딪힌 오브젝트 1개 정보 가져오기
            hitObject = hit.collider.gameObject; // hit이 부딪힌 오브젝트 가져오기
            if (hitObject == ground)
            {
                Debug.Log("Hit (x,y,z): " + hit.point.ToString("F2"));
                transform.position = hit.point;
            }

        }
    }
}
