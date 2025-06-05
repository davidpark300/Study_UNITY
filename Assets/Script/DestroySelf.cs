using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(destroyTime());
    }
    void Update()
    {
    }

    private IEnumerator destroyTime()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
