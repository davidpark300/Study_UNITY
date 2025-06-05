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
            // simplemove가 작동하면서 다음 위치로의 이동이 순간이동 시킬 좌표를 덮어씌우기 때문에 잠시 컴포넌트 끄기
            CharacterController cc = collision.gameObject.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false; // 위치 이동 전에 꼭 꺼줌
                collision.gameObject.transform.position = new Vector3(0, 1.4f, 20.0f);
                cc.enabled = true;  // 위치 이동 후 다시 켜줌
            }
        }
    }

}
