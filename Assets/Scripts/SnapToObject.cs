using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToObject : MonoBehaviour
{
    public float snapDistance = 0.2f;
    public Transform snapableObject;

    private void Start(){
 
    }

    void Update()
    {
            // Check if the Snappee object is within snap distance of the Snapable object
            Collider[] hits = Physics.OverlapSphere(snapableObject.position, snapDistance);
            foreach (Collider hit in hits)
            {
                if (hit.transform == transform)
                {
                    // Snap the Snappee object to the Snapable object
                    Debug.Log("Touches");
                    Snap();
                }

            }
        
    }

    // Called when the Snappee object is released by the player
    public void Snap() {

        // Set the Snappee object's position and rotation to match the Snapable object
        transform.position = snapableObject.position;
        transform.rotation = snapableObject.rotation;


    }

}