using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArtwork : MonoBehaviour
{
    public Texture[] images;
    private int[] randomIndexArray = new int[9];
    private int indexArrayIndex;
    private void Start()
    {
        indexArrayIndex = 0;
        foreach (Transform artwork in transform)
        {
            int randImageIndex = Random.Range(0, 81);
            randomIndexArray[indexArrayIndex++] = randImageIndex;
            GameObject art = artwork.Find("Image").gameObject;
            Renderer rend = art.GetComponent<Renderer>();
            Shader shader = Shader.Find("Standard");
            Material mat = new Material(shader);
            mat.mainTexture = images[randImageIndex];
            rend.material = mat;
        }

        foreach(int n in randomIndexArray)
        {
            Debug.Log(n);
        }
    }
    public int getArray(int i)
    {
        return randomIndexArray[i];
    }
    
}
