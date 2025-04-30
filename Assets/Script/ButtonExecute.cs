using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonExecute : MonoBehaviour
{
    private GameObject currentButton;
    private Clicker clicker = new Clicker();

    // Start is called before the first frame update
    void Start()
    {

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
            if (hit.transform.gameObject.tag == "Button")   // 태그가 Button인 오브젝트인 경우
            {
                hitButton = hit.transform.parent.gameObject;    // 오브젝트 할당
            }
        }
        if (currentButton != hitButton) //
        {
            if (currentButton != null) // 하이라이트 끄기
            {
                ExecuteEvents.Execute<IPointerExitHandler>(currentButton, data, ExecuteEvents.pointerExitHandler);
            }
            currentButton = hitButton;
            if (currentButton != null) // 하이라이트
            {
                ExecuteEvents.Execute<IPointerEnterHandler>(currentButton, data, ExecuteEvents.pointerEnterHandler);
            }
        }
        if (currentButton != null)
        {
            if (clicker.clicked())
            {
                ExecuteEvents.Execute<IPointerClickHandler>(currentButton, data, ExecuteEvents.pointerClickHandler);
            }
        }
    }
}
