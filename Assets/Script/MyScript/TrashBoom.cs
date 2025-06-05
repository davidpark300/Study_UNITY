using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBoom : MonoBehaviour
{
    public GameObject boomEffect;
    private GameObject boom;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            boom = Instantiate(boomEffect, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            StartCoroutine(destroyBoom());
        }
    }

    private IEnumerator destroyBoom()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(boom.gameObject);
    }
}
