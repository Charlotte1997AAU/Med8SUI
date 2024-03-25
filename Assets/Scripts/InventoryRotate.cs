using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryRotate : MonoBehaviour
{

    public GameObject Head;
    private float rotationSpeed = 50;

    void Update()
    {
       //Place the inventory halfway from the floor and headset - about where the hips are.
      // transform.position = new Vector3(Head.transform.position.x, Head.transform.position.y/2, Head.transform.position.z); 

       var rotationDiff = Math.Abs(Head.transform.eulerAngles.y - transform.eulerAngles.y);
       var finalRotationSpeed = rotationSpeed;

       if(rotationDiff > 60){
        finalRotationSpeed = rotationSpeed * 2;
       }
       else if(rotationDiff > 40 && rotationDiff < 60){
        finalRotationSpeed = rotationSpeed;
       }
       else if(rotationDiff < 40 && rotationDiff > 20){
        finalRotationSpeed = rotationSpeed / 2;
       }
       else if(rotationDiff < 20 && rotationDiff > 0){
        finalRotationSpeed = rotationSpeed / 4;
       }

       var step = finalRotationSpeed * Time.deltaTime;
       transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, Head.transform.eulerAngles.y, 0), step);
    }
}
