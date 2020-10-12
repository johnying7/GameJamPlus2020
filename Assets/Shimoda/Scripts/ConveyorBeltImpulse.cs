using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltImpulse : MonoBehaviour
{
    public float conveyorBeltImpulse;
    //public bool right;
    private void OnTriggerStay(Collider other){
        Debug.Log("Tag: " + other.tag);
        if(other.tag.Equals("PlayerGroundTrigger")){
            // Applies force to the rigidbody
            Debug.Log("Applying force");
            other.transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(conveyorBeltImpulse, 0, 0 ));
        }
    }
    private void OnTriggerExit(Collider other){
        Debug.Log("Tag: " + other.tag);
    }

}
