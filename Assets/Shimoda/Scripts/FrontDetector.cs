using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FrontDetector : MonoBehaviour
{
    public string pushableTag;
    public UnityEvent EnterPushable;
    public UnityEvent LeavePushable;
    public Rigidbody pushableBody;

    void Start(){
        if(EnterPushable == null) EnterPushable = new UnityEvent();
        if(LeavePushable == null) LeavePushable = new UnityEvent();

    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == pushableTag){
            Debug.Log("There is a pushable object in front");
            pushableBody = other.GetComponent<Rigidbody>();
            if(EnterPushable != null) EnterPushable.Invoke();
        } 
    }
    private void OnTriggerExit(Collider other){
        if(other.tag == pushableTag){
            Debug.Log("Left Pushable object realm");
            FreezeIt();
            pushableBody = null;
            if(LeavePushable != null) LeavePushable.Invoke();
        } 
    }

    public void MakeItMove(){
        if(pushableBody != null)
        {
            Debug.Log("Changing Constraints");
            pushableBody.constraints =  RigidbodyConstraints.FreezeRotationX | 
                                        RigidbodyConstraints.FreezeRotationY | 
                                        RigidbodyConstraints.FreezeRotationZ | 
                                        RigidbodyConstraints.FreezePositionY | 
                                        RigidbodyConstraints.FreezePositionZ;

        }

    }

    public void FreezeIt(){
        if(pushableBody != null)
        {
            Debug.Log("Freezing Constraints");
            pushableBody.constraints = RigidbodyConstraints.FreezeRotationX | 
                                        RigidbodyConstraints.FreezeRotationY | 
                                        RigidbodyConstraints.FreezeRotationZ | 
                                        RigidbodyConstraints.FreezePositionX | 
                                        RigidbodyConstraints.FreezePositionY | 
                                        RigidbodyConstraints.FreezePositionZ;
        }
    }

}
