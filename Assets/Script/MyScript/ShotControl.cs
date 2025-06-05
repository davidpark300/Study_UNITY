using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject bulletInstance;
    private Clicker clicker = new Clicker();

    // Update is called once per frame
    void Update()
    {
        shot();
    }

    private void shot()
    {
        if (clicker.rKeyClicked())
        {
            bulletInstance = Instantiate(bulletPrefab);
            bulletInstance.transform.position = transform.position + Camera.main.transform.forward * 1.2f;
            bulletInstance.transform.rotation = Camera.main.transform.rotation;
        }
    }

}
