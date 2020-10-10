using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundContact : MonoBehaviour
{
    private bool isGrounded = true;

    public bool Check(){
        return isGrounded;
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("TriggerEnter: " + other.tag);
        if(other.tag.Equals("Ground")){
            Debug.Log("You're grounded");
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other){
        Debug.Log("TriggerExit: " + other.tag);
        if(other.tag.Equals("Ground")){
            Debug.Log("Floating in the air");
            isGrounded = false;
        }
    }

}
