using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTarget : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f; // countDown 값 리셋 용도
    public int score;
    private float countDown; // 대상을 보고 있는 시간
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        countDown = timeToSelect;
        var emission = hitEffect.emission;
        emission.enabled = false;
        //hitEffect.emission.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f);
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit; // 장애물 뒤에 있을 때는 광선이 맞은 판정이 되면 안됨
        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target)) // 광선이 hit 여부 체크하고 hit한 오브젝트가 target인 경우
        {
            if (countDown > 0.0f)
            {
                // 에단이 조준 되었을 때
                countDown -= Time.deltaTime; // deltaTime은 프레임과 프레임 사이의 걸린 시간, 컴퓨터 사양에 관련 없다
                // print(countDown);
                hitEffect.transform.position = hit.point; // 바라봐진 지점
                var emission = hitEffect.emission;
                emission.enabled = true;
                //hitEffect.emission.enabled = true;
            }
            else
            {
                // 에단이 죽었을 때
                Instantiate(killEffect, target.transform.position, target.transform.rotation); // killEffect 개체 만들어라
                score += 1;
                Debug.Log(score);
                countDown = timeToSelect;
                SetRandomPosition(); // 바라봐져서 죽은 대상 오브젝트 위치 랜덤 조정
            }
        }
        else
        {
            // reset
            countDown = timeToSelect;
            var emission = hitEffect.emission;
            emission.enabled = false;
            //hitEffect.emission.enabled = false;
        }
    }
    void SetRandomPosition()
    {
        float x =  Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        target.transform.position = new Vector3(x, 0.0f, z);
        Debug.Log(target.transform.position);
    }
}

// world &&& global
// local pos &&& global pos
// Transform에 있는 Reset은 월드 좌표랑 맞추는 것
// 모든 오브젝트는 각자의 local 좌표계가 있음
// world 좌표계와 local 좌표계가 다름