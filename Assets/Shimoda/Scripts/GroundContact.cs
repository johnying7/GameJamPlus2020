using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundContact : MonoBehaviour
{
    public UnityEvent OffTheGround;
    public UnityEvent BackToGround;
    public string[] groundTags;
    private bool isGrounded = true;
    private string groundie;

    void Start(){
        if(BackToGround == null) BackToGround = new UnityEvent();
        if(OffTheGround == null) OffTheGround = new UnityEvent();
        
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
            //Debug.Log("You're grounded");
            isGrounded = true;
            if(BackToGround != null) BackToGround.Invoke();
        }
    }
    private void OnTriggerExit(Collider other){
        //Debug.Log("TriggerExit: " + other.tag);
        if(groundie.IndexOf("|" + other.tag + "|") >=0){
            //Debug.Log("Floating in the air");
            isGrounded = false;
        }
    }
    public void JumpAnimStarted(){
        //Debug.Log("Whoa");
        if(OffTheGround != null) OffTheGround.Invoke();
    }

}
