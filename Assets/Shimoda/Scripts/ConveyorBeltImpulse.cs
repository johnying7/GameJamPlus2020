using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltImpulse : MonoBehaviour
{
    public float conveyorBeltImpulse;
    //public bool right;
    private void OnTriggerStay(Collider other){
        if(other.tag.Equals("PlayerGroundTrigger")){
            other.transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(conveyorBeltImpulse, 0, 0 ));
        }
    }
    private void OnTriggerExit(Collider other){
        Debug.Log("Tag: " + other.tag);
    }

}
