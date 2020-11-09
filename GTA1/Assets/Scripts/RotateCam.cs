using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    public int  sensitivityX = 10;
    void Update()
    {
        if(Input.GetButton("E") && Input.GetAxis("Mouse X")<0){
            transform.Rotate(0, -sensitivityX, 0);
        }
        if(Input.GetButton("E") && Input.GetAxis("Mouse X")>0){
            transform.Rotate(0, sensitivityX, 0);
        }

        
    }
}
