using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoUIControl : MonoBehaviour
{
    public GameObject infoUI;
    private bool infoUIIsActivated;
    private Clicker clicker = new Clicker();
    // Start is called before the first frame update
    void Start()
    {
        infoUIIsActivated = false;
        infoUI.SetActive(infoUIIsActivated);
    }

    // Update is called once per frame
    void Update()
    {
        controlInfoUI();
    }

    private void controlInfoUI()
    {
        //infoUI.transform.rotation = Quaternion.Euler(new Vector3(0.0f, Camera.main.transform.rotation.eulerAngles.y, 0.0f));
        if (clicker.qKeyClicked())
        {
            infoUIIsActivated = !infoUIIsActivated;
            infoUI.SetActive(infoUIIsActivated);
        }
    }
}
