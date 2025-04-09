using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTarget : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f; // countDown �� ���� �뵵
    public int score;
    private float countDown; // ����� ���� �ִ� �ð�
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
        RaycastHit hit; // ��ֹ� �ڿ� ���� ���� ������ ���� ������ �Ǹ� �ȵ�
        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target)) // ������ hit ���� üũ�ϰ� hit�� ������Ʈ�� target�� ���
        {
            if (countDown > 0.0f)
            {
                // ������ ���� �Ǿ��� ��
                countDown -= Time.deltaTime; // deltaTime�� �����Ӱ� ������ ������ �ɸ� �ð�, ��ǻ�� ��翡 ���� ����
                // print(countDown);
                hitEffect.transform.position = hit.point; // �ٶ���� ����
                var emission = hitEffect.emission;
                emission.enabled = true;
                //hitEffect.emission.enabled = true;
            }
            else
            {
                // ������ �׾��� ��
                Instantiate(killEffect, target.transform.position, target.transform.rotation); // killEffect ��ü ������
                score += 1;
                Debug.Log(score);
                countDown = timeToSelect;
                SetRandomPosition(); // �ٶ������ ���� ��� ������Ʈ ��ġ ���� ����
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
// Transform�� �ִ� Reset�� ���� ��ǥ�� ���ߴ� ��
// ��� ������Ʈ�� ������ local ��ǥ�谡 ����
// world ��ǥ��� local ��ǥ�谡 �ٸ�