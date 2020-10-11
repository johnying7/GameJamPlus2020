using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTouch : MonoBehaviour
{
    public UnityEvent DeathTouch;
    public UnityEvent OffTheGround;
    public UnityEvent BackToGround;
    public UnityEvent NearSwitch;
    public UnityEvent AwayFromSwitch;
    
    public string[] groundTags;
    public string[] deathTags;
    private bool isGrounded = true;
    private string groundie;
    private string deathie;

    void Start(){
        if(BackToGround == null) BackToGround = new UnityEvent();
        if(OffTheGround == null) OffTheGround = new UnityEvent();
        if(DeathTouch == null) DeathTouch = new UnityEvent();

        foreach(string gnd in groundTags){
            groundie += "|" + gnd + "|"; 
        }
        foreach(string dth in deathTags){
            deathie += "|" + dth + "|";
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
        } else if (deathie.IndexOf("|"+other.tag+"|") >= 0){
            if(DeathTouch != null) DeathTouch.Invoke();
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
