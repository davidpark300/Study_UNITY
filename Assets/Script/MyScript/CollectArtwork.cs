using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectArtwork : MonoBehaviour
{
    private bool collectPermission;

    private float timeToSelect = 3.0f; // countDown �� ���� �뵵
    public int artCount;    // ã�� �׸� ����
    private float countDown; // ����� ���� �ִ� �ð�
    public Text collectText;  // �׸� ���� �ؽ�Ʈ ������Ʈ �뵵
    public Transform[] progressBar;   // �׸� ȸ���ϱ� Ȯ���ϴ� ���α׷��� ��

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
        artCount = 0;   // ó������ �׸� ���� ���� ������ 0���� �ʱ�ȭ
        countDown = timeToSelect;   // ���α׷��� �ٿ��� ����� ī��Ʈ �ٿ� �ʱ�ȭ
        foreach (Transform t in progressBar)
        {
            t.gameObject.SetActive(false);    // ���α׷��� �� ó������ ��Ȱ��ȭ
        }
        collectText.text = "0 / 9"; // �׸� ���� �ؽ�Ʈ �ʱⰪ ����
    }
    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;   // ���� ī�޶��� transform ��������
        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f); // �Ͼ�� ������ ���� ������ϱ�
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);  // ������ �������� �������� ������ ���� ����
        RaycastHit hit; // ��ֹ� �ڿ� ���� ���� ������ ���� ������ �Ǹ� �ȵ�
        if (collectPermission)
        {
            // ������ hit ���� üũ�ϰ� hit�� ������Ʈ�� Artwork �±��� ���
            if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.tag == "Artwork") && artCount < 9) 
            {
                if (countDown > 0.0f)   // ī��Ʈ �ٿ��� 0�� �ƴ� ��
                {
                    progressBar[artCount].gameObject.SetActive(true); // ������ �׸��� ����� �� Ȱ��ȭ
                    countDown -= Time.deltaTime; // deltaTime�� �����Ӱ� ������ ������ �ɸ� �ð�, ��ǻ�� ��翡 ���� ����

                    // �׸��� ȸ���ǰ� �ִ��� �˱� ���� ���α׷��� ����
                    Vector3 scale = progressBar[artCount].localScale; // ���α׷��� ���� ���� ������ ����
                    scale.x += 0.28f * Time.deltaTime;  // ������ ���� Ű���
                    scale.x = Mathf.Clamp(scale.x, 0f, 1f); // �ε巴�� �������� ����ǵ��� Mathf.Clamp���
                    progressBar[artCount].localScale = scale; // ���ο� �������� ���α׷��� ���� �����Ϸ� ����

                    Vector3 pos = progressBar[artCount].position; // ���α׷��� ���� ���� ��ġ ����
                    pos.x += 0.14f * Time.deltaTime;    // ���α׷��� ���� ��ġ �̵�
                    progressBar[artCount].position = pos; // ���ο� ��ġ�� ���α׷��� ���� ��ġ�� ����
                }
                else // ī��Ʈ �ٿ��� 0�� ��
                {
                    updateCollection(artCount);

                    // ���̻� �����̶� �浹���� ���ϵ��� ���α׷��� �ٸ� ���������� Ȱ���Ͽ� �׸� ������
                    Vector3 finishScale = progressBar[artCount].localScale;   // ���α׷��� ���� ������ ����   
                    finishScale.y = 0.75f;  // ���α׷��� ���� ���� ������ ���� ��Ű��
                    progressBar[artCount].localScale = finishScale;   // ���α׷��� ���� �����Ͽ� ����
                    Vector3 finishPos = progressBar[artCount].localPosition;  // ���α׷��� ���� ��ġ ����
                    finishPos.x = 0.0f; // ������ ��ġ�� �׸���ġ�� �����ϰ� ����
                    finishPos.y = 0.0f;
                    progressBar[artCount].localPosition = finishPos;  // ���ο� ��ġ�� ��ġ ����

                    artCount += 1;  // ���� �׸� ���� ����
                    collectText.text = artCount + " / 9";   // �׸� ���� �ؽ�Ʈ ����
                    countDown = timeToSelect;   // ī��Ʈ �ٿ� �ʱ�ȭ
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
