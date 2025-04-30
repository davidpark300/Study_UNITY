using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookMoveTo : MonoBehaviour
{
    public GameObject ground;
    public Transform infoBubble;
    private Text infoText;

    // Start is called before the first frame update
    void Start()
    {
        if(infoBubble != null)
        {
            infoText = infoBubble.Find("Text (Legacy)").GetComponent<Text>();   // Text (Legacy) 라는 이름을 가진 인스턴스 가져와서 초기화
        }
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
                if(infoBubble != null)
                {
                    infoText.text = "X:" + hit.point.x.ToString("F2") + "Z:" + hit.point.z.ToString("F2");  // infoBubble로 들어온 오브젝트의 좌표 가져와서 저장
                    infoBubble.LookAt(camera.position); // infoBubble의 방향을 카메라 방향과 맞춤
                    infoBubble.Rotate(0.0f, 180.0f, 0.0f);  // 방향을 맞추면 안보이니까 180도 회전
                }
                Debug.Log(infoBubble.name);
                transform.position = hit.point;
            }

        }
    }
}
