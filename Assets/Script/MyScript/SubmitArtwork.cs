using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitArtwork : MonoBehaviour
{
    public GameObject[] pictures;
    private Sprite[] sprites;
    private int spriteIndex;
    private bool isFinished;
    private Clicker clicker = new Clicker();

    private void Start()
    {
        isFinished = false;
        sprites = new Sprite[pictures.Length];
    }

    private void Update()
    {
        if (isFinished)
        {
            for (int i = 0; i < pictures.Length; i++)
            {
                sprites[i] = pictures[i].GetComponent<Image>().sprite;
            }
            Transform camera = Camera.main.transform;   // 메인 카메라의 transform 가져오기
            Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f); // 하얀색 광선을 쏴서 디버깅하기
            Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);  // 광선의 시작점과 도착점을 설정한 광선 생성
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.tag == "SubmitArt"))
            {
                if (clicker.eKeyClicked())
                    if (spriteIndex < pictures.Length)
                    {
                        GameObject art = hit.collider.gameObject;
                        Renderer rend = art.GetComponent<Renderer>();
                        Shader shader = Shader.Find("Standard");
                        Material mat = new Material(shader);
                        mat.mainTexture = sprites[spriteIndex].texture;
                        rend.material = mat;
                        spriteIndex++;
                        //hit.collider.gameObject.GetComponent<MeshCollider>().enabled = false;
                    }
            }
        }
    }

    public void setIsFinished()
    {
        isFinished = true;
    }

}
