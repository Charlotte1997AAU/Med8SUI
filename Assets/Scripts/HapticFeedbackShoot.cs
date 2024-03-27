using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedbackShoot : MonoBehaviour
{

   
    [Range(0.0f, 1.0f)]
    public float intesity;

    public float duration;
    public AudioSource audioSource;
    public AudioClip gunshot;

    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(TriggerHaptic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TriggerHaptic(BaseInteractionEventArgs eventArgs){
        if(eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor){
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    public void TriggerHaptic(XRBaseController controller){
        if (intesity > 0){
            controller.SendHapticImpulse(intesity, duration);
        }
        if (audioSource && gunshot){
            audioSource.PlayOneShot(gunshot);
        }
    }
}
