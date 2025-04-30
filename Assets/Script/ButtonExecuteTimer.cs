using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonExecuteTimer : MonoBehaviour
{
    public float timeToSelect = 5.0f;
    private float countDown;
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
                countDown = timeToSelect;
            }
        }
        if (currentButton != null)
        {
            if (clicker.clicked())
            {
                countDown -= Time.deltaTime;
                if (clicker.clicked() || countDown < 0.0f)
                {
                    ExecuteEvents.Execute<IPointerClickHandler>(currentButton, data, ExecuteEvents.pointerClickHandler);
                    countDown = timeToSelect;
                }
            }
        }
    }
}
