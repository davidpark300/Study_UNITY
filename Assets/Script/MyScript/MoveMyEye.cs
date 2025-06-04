using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MoveMyEye : MonoBehaviour
{
    public float walkSpeed = 0.3f;
    public float xRotate = 0.5f;
    public float yRotate = 0.5f;
    private bool isWalking = false;

    private Clicker clicker = new Clicker();
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        eyeWalking();
        eyeRotating();
    }

    private void eyeWalking()
    {
        if (clicker.mouseLeftClicked())
        {
            isWalking = !isWalking;
        }
        if (isWalking)
        {
            characterController.SimpleMove(Camera.main.transform.forward * walkSpeed);
        }
    }

    private void eyeRotating()
    {
        Transform ct = Camera.main.transform;
        if (clicker.wKeyClicked())
        {
            if (Camera.main.transform.eulerAngles.x >= 270.0f || Camera.main.transform.eulerAngles.x <= 90.0f)
            {
                Camera.main.transform.rotation =
                    Quaternion.Euler(new Vector3
                    (ct.rotation.eulerAngles.x - xRotate,
                    ct.rotation.eulerAngles.y,
                    ct.rotation.eulerAngles.z));
                //transform.rotation = 
                //    Quaternion.Euler(new Vector3
                //    (transform.rotation.eulerAngles.x - xRotate, 
                //    transform.rotation.eulerAngles.y, 
                //    transform.rotation.eulerAngles.z));
            }
        }
        if (clicker.aKeyClicked())
        {
            Camera.main.transform.rotation =
                Quaternion.Euler(new Vector3
                (ct.rotation.eulerAngles.x,
                ct.rotation.eulerAngles.y - yRotate,
                ct.rotation.eulerAngles.z));
            //transform.rotation = 
            //    Quaternion.Euler(new Vector3
            //    (transform.rotation.eulerAngles.x, 
            //    transform.rotation.eulerAngles.y - yRotate, 
            //    transform.rotation.eulerAngles.z));
        }
        if (clicker.sKeyClicked())
        {
            if (Camera.main.transform.eulerAngles.x <= 90.0f || Camera.main.transform.eulerAngles.x >= 270.0f)
            {
                Camera.main.transform.rotation =
                    Quaternion.Euler(new Vector3
                    (ct.rotation.eulerAngles.x + xRotate,
                    ct.rotation.eulerAngles.y,
                    ct.rotation.eulerAngles.z));
                //transform.rotation = 
                //    Quaternion.Euler(new Vector3
                //    (transform.rotation.eulerAngles.x + xRotate, 
                //    transform.rotation.eulerAngles.y, 
                //    transform.rotation.eulerAngles.z));
            }
        }
        if (clicker.dKeyClicked())
        {
            Camera.main.transform.rotation =
                Quaternion.Euler(new Vector3
                (ct.rotation.eulerAngles.x,
                ct.rotation.eulerAngles.y + yRotate,
                ct.rotation.eulerAngles.z));
            //transform.rotation = 
            //    Quaternion.Euler(new Vector3
            //    (transform.rotation.eulerAngles.x, 
            //    transform.rotation.eulerAngles.y + yRotate, 
            //    transform.rotation.eulerAngles.z));
        }
    }
}
