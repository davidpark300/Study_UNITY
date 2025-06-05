using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    
    private void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // simplemove�� �۵��ϸ鼭 ���� ��ġ���� �̵��� �����̵� ��ų ��ǥ�� ������ ������ ��� ������Ʈ ����
            CharacterController cc = collision.gameObject.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false; // ��ġ �̵� ���� �� ����
                collision.gameObject.transform.position = new Vector3(0, 1.4f, 20.0f);
                cc.enabled = true;  // ��ġ �̵� �� �ٽ� ����
            }
        }
    }

}
