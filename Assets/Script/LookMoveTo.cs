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
            infoText = infoBubble.Find("Text (Legacy)").GetComponent<Text>();   // Text (Legacy) ��� �̸��� ���� �ν��Ͻ� �����ͼ� �ʱ�ȭ
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
        ray = new Ray(camera.position, camera.rotation * Vector3.forward * 100.0f); // ī�޶� ���� ���⿡ ���� ray�� ����� ���� �չ��� ����?
        hits = Physics.RaycastAll(ray); // RaycastAll�� ������ �ε��� ��� ������Ʈ ������ ���ʴ�� ������
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i]; // ������ �ε��� ������Ʈ 1�� ���� ��������
            hitObject = hit.collider.gameObject; // hit�� �ε��� ������Ʈ ��������
            if (hitObject == ground)
            {
                if(infoBubble != null)
                {
                    infoText.text = "X:" + hit.point.x.ToString("F2") + "Z:" + hit.point.z.ToString("F2");  // infoBubble�� ���� ������Ʈ�� ��ǥ �����ͼ� ����
                    infoBubble.LookAt(camera.position); // infoBubble�� ������ ī�޶� ����� ����
                    infoBubble.Rotate(0.0f, 180.0f, 0.0f);  // ������ ���߸� �Ⱥ��̴ϱ� 180�� ȸ��
                }
                Debug.Log(infoBubble.name);
                transform.position = hit.point;
            }

        }
    }
}
