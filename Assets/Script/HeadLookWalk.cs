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
        moveDirection *= velocity * Time.deltaTime; // �ý��� ���� ������� ������ ������ �귯��
        moveDirection.y = 0.0f;
        //transform.position += moveDirection;    // transform�� ���� ��ũ��Ʈ�� ���� ������Ʈ�� ������Ʈ
        controller.Move(moveDirection); // �߷� ���� ������
        */
        if (clicker.clicked())  // �ڵ� ��Ʈ�ѷ����� �Է¿� ���� ������ ������ ���� �κ�
        {
            isWalking = !isWalking;
        }
        if (isWalking)
        {
            controller.SimpleMove(Camera.main.transform.forward * velocity);    // �߷� �ۿ� ������ �̵�
        }
    }
}
