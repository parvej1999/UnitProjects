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
    void Update()
    {
        if(Input.GetButton("Horizontal")){
            Debug.Log("Pressed horizontal");
        }

        if(Input.GetButton("Vertical")){
            Debug.Log("Pressed vertical");
        }

        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")){
            Debug.Log("pressed");
            thePlayer.GetComponent<Animation>().Play("Run_Rifle");
            horizontalMove = horizontalMove + Input.GetAxis("Horizontal") * Time.deltaTime * 150;
            verticalMove = verticalMove + Input.GetAxis("Vertical") * Time.deltaTime * 8;
            isWalking = true;
            transform.Rotate(0, horizontalMove, 0);
            transform.Translate(0,0,verticalMove);
        }
        else{
            thePlayer.GetComponent<Animation>().Play("Idle_Rifle");
            isWalking = false;
            horizontalMove = 0;
            // Debug.Log("Released");
        }
    }
}
