using UnityEngine;
using UnityEngine.XR;

public class PlayerHeight : MonoBehaviour
{
    public GameObject HMDobject;

    public GameObject blueholster;

    void Start()
    {
        placeHolster(blueholster, HMDobject);
        
    }

    void Update(){


    }


    void placeHolster(GameObject holster, GameObject HMDPos) {
    if (holster != null && HMDPos != null) {
        float HMDHeight = HMDPos.transform.position.y;
        Debug.Log("HMD Height: " + HMDHeight);
        
        Vector3 newPosition = new Vector3(holster.transform.position.x, HMDHeight * 0.4f, holster.transform.position.z);
        holster.transform.position = newPosition;

        Debug.Log("New Holster Position: " + holster.transform.position);
    }
}

}
