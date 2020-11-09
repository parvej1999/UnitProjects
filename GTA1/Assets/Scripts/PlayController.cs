using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{// Update is called once per frame
    public GameObject thePlayer;
    public bool isRunning;
    public bool isWalking;
    public float horizontalMove;
    public float verticalMove;
    public int RotationSensitivity=10;
    // public int jumpHeight=10;
    public float force = 1.0f;
    public Rigidbody rb;
    public bool isGrounded;

    void start(){
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    void OnCollisionExit(){
            isGrounded = false;
    }

    void Update()
    {

        if(!(Input.GetButton("E")) && Input.GetAxis("Mouse X")<0){
            transform.Rotate(0, -RotationSensitivity, 0);
            }
        if(!(Input.GetButton("E")) && Input.GetAxis("Mouse X")>0){
            transform.Rotate(0, RotationSensitivity, 0);
        }

        if(Input.GetButtonDown("Jump") && isGrounded){
            thePlayer.GetComponent<Animation>().Play("Jump_Rifle");
            rb.AddForce(0, force, 0, ForceMode.Impulse);
            isGrounded = false;
            // this.transform.Translate(0, jumpHeight, 0);
        }

        if(Input.GetButton("W")){
            // Debug.Log("pressed");
            if(Input.GetButton("LeftShift")){
                // if(isGrounded){
                //     thePlayer.GetComponent<Animation>().Play("Jump_Rifle");
                // }
                // else{
                thePlayer.GetComponent<Animation>().Play("Run_Rifle");
                // }
                isRunning = true;
                horizontalMove =Input.GetAxis("Horizontal") * Time.deltaTime * 150;
                verticalMove =Input.GetAxis("Vertical") * Time.deltaTime * 8;
            }

            else{
                // if(isGrounded){
                //     thePlayer.GetComponent<Animation>().Play("Jump_Rifle");
                // }
                // else{
                thePlayer.GetComponent<Animation>().Play("Walk_Rifle");
                // }
                horizontalMove =Input.GetAxis("Horizontal") * Time.deltaTime * 100;
                verticalMove =Input.GetAxis("Vertical") * Time.deltaTime * 8;
                isWalking = true;
            }
            transform.Rotate(0, horizontalMove, 0);
            transform.Translate(0,0,verticalMove);
            
        }


        else{
            thePlayer.GetComponent<Animation>().Play("Idle_Rifle");
            isWalking = false;
            isRunning = false;

            // Debug.Log("Released");
        }
    }
}
