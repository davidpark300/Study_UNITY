using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectArtwork : MonoBehaviour
{
    private bool collectPermission;

    private float timeToSelect = 3.0f; // countDown 값 리셋 용도
    public int artCount;    // 찾은 그림 갯수
    private float countDown; // 대상을 보고 있는 시간
    public Text collectText;  // 그림 갯수 텍스트 업데이트 용도
    public Transform[] progressBar;   // 그림 회수하기 확인하는 프로그래스 바

    public RandomArtwork randomArtwork;
    public SubmitArtwork submitArtwork;
    public Sprite[] sprites;
    public GameObject[] pictures;
    private int picturesIndex;

    // Start is called before the first frame update
    void Start()
    {
        collectPermission = false;
        picturesIndex = 0;
        artCount = 0;   // 처음에는 그림 모은 것이 없으니 0으로 초기화
        countDown = timeToSelect;   // 프로그래스 바에서 사용할 카운트 다운 초기화
        foreach (Transform t in progressBar)
        {
            t.gameObject.SetActive(false);    // 프로그래스 바 처음에는 비활성화
        }
        collectText.text = "0 / 9"; // 그림 갯수 텍스트 초기값 설정
    }
    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;   // 메인 카메라의 transform 가져오기
        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f); // 하얀색 광선을 쏴서 디버깅하기
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);  // 광선의 시작점과 도착점을 설정한 광선 생성
        RaycastHit hit; // 장애물 뒤에 있을 때는 광선이 맞은 판정이 되면 안됨
        if (collectPermission)
        {
            // 광선이 hit 여부 체크하고 hit한 오브젝트가 Artwork 태그인 경우
            if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.tag == "Artwork") && artCount < 9) 
            {
                if (countDown > 0.0f)   // 카운트 다운이 0이 아닐 때
                {
                    progressBar[artCount].gameObject.SetActive(true); // 광선이 그림에 닿았을 때 활성화
                    countDown -= Time.deltaTime; // deltaTime은 프레임과 프레임 사이의 걸린 시간, 컴퓨터 사양에 관련 없다

                    // 그림이 회수되고 있는지 알기 위해 프로그래스 설정
                    Vector3 scale = progressBar[artCount].localScale; // 프로그래스 바의 원본 스케일 저장
                    scale.x += 0.28f * Time.deltaTime;  // 스케일 점점 키우기
                    scale.x = Mathf.Clamp(scale.x, 0f, 1f); // 부드럽게 스케일이 변경되도록 Mathf.Clamp사용
                    progressBar[artCount].localScale = scale; // 새로운 스케일은 프로그래스 바의 스케일로 설정

                    Vector3 pos = progressBar[artCount].position; // 프로그래스 바의 원래 위치 저장
                    pos.x += 0.14f * Time.deltaTime;    // 프로그래스 바의 위치 이동
                    progressBar[artCount].position = pos; // 새로운 위치는 프로그래스 방의 위치로 설정
                }
                else // 카운트 다운이 0일 때
                {
                    updateCollection(artCount);

                    // 더이상 광선이랑 충돌하지 못하도록 프로그래스 바를 가림막으로 활용하여 그림 가리기
                    Vector3 finishScale = progressBar[artCount].localScale;   // 프로그래스 바의 스케일 저장   
                    finishScale.y = 0.75f;  // 프로그래스 바의 세로 스케일 증가 시키기
                    progressBar[artCount].localScale = finishScale;   // 프로그래스 바의 스케일에 적용
                    Vector3 finishPos = progressBar[artCount].localPosition;  // 프로그래스 바의 위치 저장
                    finishPos.x = 0.0f; // 가림막 위치를 그림위치와 동일하게 설정
                    finishPos.y = 0.0f;
                    progressBar[artCount].localPosition = finishPos;  // 새로운 위치로 위치 조정

                    artCount += 1;  // 모은 그림 갯수 증가
                    collectText.text = artCount + " / 9";   // 그림 갯수 텍스트 변경
                    countDown = timeToSelect;   // 카운트 다운 초기화
                    if (artCount == 9)
                    {
                        submitArtwork.setIsFinished();
                    }
                }
            }
        }
    }

    private void updateCollection(int ac)
    {
        picturesIndex = randomArtwork.getArray(ac);
        Debug.Log(picturesIndex);
        pictures[ac].GetComponent<Image>().sprite = sprites[picturesIndex];
    }

    public void isEnableCollect()
    {
        collectPermission = true;
    }

    public void isDisableCollect()
    {
        collectPermission = false;
    }
}
