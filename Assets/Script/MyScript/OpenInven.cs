using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenInven : MonoBehaviour
{
    private GameObject currentButton;
    private Clicker clicker = new Clicker();

    public GameObject invenObject;
    private bool invenIsActived;

    // Start is called before the first frame update
    void Start()
    {
        invenIsActived = false;
        invenObject.SetActive(invenIsActived);
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        GameObject hitButton = null;
        PointerEventData data = new PointerEventData(EventSystem.current);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Button")   // �±װ� Button�� ������Ʈ�� ���
            {
                hitButton = hit.transform.parent.gameObject;    // ������Ʈ �Ҵ�
            }
        }
        if (currentButton != hitButton) //
        {
            if (currentButton != null) // ���̶���Ʈ ����
            {
                ExecuteEvents.Execute<IPointerExitHandler>(currentButton, data, ExecuteEvents.pointerExitHandler);
            }
            currentButton = hitButton;
            if (currentButton != null) // ���̶���Ʈ
            {
                ExecuteEvents.Execute<IPointerEnterHandler>(currentButton, data, ExecuteEvents.pointerEnterHandler);
            }
        }
        if (currentButton != null)
        {
            if (clicker.mouseRightClicked())
            {
                ExecuteEvents.Execute<IPointerClickHandler>(currentButton, data, ExecuteEvents.pointerClickHandler);
            }
        }
    }

    public void OpenClick()
    {
        invenIsActived = !invenIsActived;
        invenObject.SetActive(invenIsActived);
    }

}
