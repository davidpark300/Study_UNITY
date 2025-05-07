using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLookWalk : MonoBehaviour
{
    public float velocity = 0.3f;
    public bool isWalking = false;

    private CharacterController controller;
    private Clicker clicker = new Clicker();

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 moveDirection = Camera.main.transform.forward;
        moveDirection *= velocity * Time.deltaTime; // 시스템 성능 상관없이 일정한 프레임 흘러감
        moveDirection.y = 0.0f;
        //transform.position += moveDirection;    // transform은 지금 스크립트가 붙은 오브젝트의 컴포넌트
        controller.Move(moveDirection); // 중력 없이 진행함
        */
        if (clicker.clicked())  // 핸드 콘트롤러에서 입력에 대한 움직임 설정에 대한 부분
        {
            isWalking = !isWalking;
        }
        if (isWalking)
        {
            controller.SimpleMove(Camera.main.transform.forward * velocity);    // 중력 작용 받으며 이동
        }
    }
}
