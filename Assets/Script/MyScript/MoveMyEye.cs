using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MoveMyEye : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float xRotate = 0.5f;
    public float yRotate = 0.5f;
    private bool isWalking = false;

    private Clicker clicker = new Clicker();
    private CharacterController characterController;

    public float bounceForce = 0.0f;
    private float verticalVelocity = 0.0f;
    public float gravity = 9.8f;
    private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        eyeWalkingAndJumping();
        eyeRotating();
    }

    private void eyeWalkingAndJumping()
    {
    
        if (clicker.mouseLeftClicked())
        {
            Debug.Log(isWalking);
            isWalking = !isWalking;
        }
        if (isWalking)
        {
            moveDirection = Camera.main.transform.forward * walkSpeed;
            //characterController.SimpleMove(Camera.main.transform.forward * walkSpeed + Camera.main.transform.up * verticalVelocity);
        }
        else
        {
            moveDirection = Vector3.zero;
        }
        if (characterController.isGrounded)
        {
            verticalVelocity = 0.0f;
        }
        if (bounceForce != 0.0f)
        {
            Debug.Log("มกวมทย : "+bounceForce);
            verticalVelocity = bounceForce * 0.02f;
            bounceForce = 0.0f;
        }
        moveDirection.y = verticalVelocity;
        verticalVelocity -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
        
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
