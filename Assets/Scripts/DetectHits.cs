using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHits : MonoBehaviour
{
    

    public int hits;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Bullet")){
            hits+=1;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}