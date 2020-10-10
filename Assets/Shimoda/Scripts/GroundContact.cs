using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundContact : MonoBehaviour
{
    public string[] groundTags;
    private bool isGrounded = true;
    private string groundie;

    void Start(){
        foreach(string gnd in groundTags){
            groundie += "|" + gnd + "|"; 
        }
    }
    public bool Check(){
        return isGrounded;
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("TriggerEnter: " + other.tag);
        if(groundie.IndexOf("|" + other.tag + "|") >=0){
            Debug.Log("You're grounded");
            isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other){
        Debug.Log("TriggerExit: " + other.tag);
        if(groundie.IndexOf("|" + other.tag + "|") >=0){
            Debug.Log("Floating in the air");
            isGrounded = false;
        }
    }

}
