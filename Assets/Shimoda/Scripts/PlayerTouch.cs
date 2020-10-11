using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTouch : MonoBehaviour
{
    //public UnityEvent DeathTouch;
    public UnityEvent DeathAnimationEnd;
    public UnityEvent StandUpAnimationEnd;
    public UnityEvent OffTheGround;
    public UnityEvent BackToGround;
    public UnityEvent NearSwitch;
    public UnityEvent AwayFromSwitch;
    public UnityEvent SwitchAnimationEnd; 
    
    public string[] groundTags;
    public string[] deathTags;
    public string[] switchTags;
    private bool isGrounded = true;
    private string groundie;
    private string deathie;
    private string switchie;

    void Start(){
        if(BackToGround == null) BackToGround = new UnityEvent();
        if(OffTheGround == null) OffTheGround = new UnityEvent();
        //if(DeathTouch == null) DeathTouch = new UnityEvent();
        if(NearSwitch == null) NearSwitch = new UnityEvent();
        if(AwayFromSwitch == null) AwayFromSwitch = new UnityEvent();
        if(DeathAnimationEnd == null) DeathAnimationEnd = new UnityEvent();
        if(SwitchAnimationEnd == null) SwitchAnimationEnd = new UnityEvent();
        if(StandUpAnimationEnd == null) StandUpAnimationEnd = new UnityEvent();

        foreach(string gnd in groundTags){
            groundie += "|" + gnd + "|"; 
        }
        foreach(string dth in deathTags){
            deathie += "|" + dth + "|";
        }
        foreach(string sth in switchTags){
            switchie +=  "|" + sth + "|";
        }
    }
    public bool Check(){
        return isGrounded;
    }

    private void OnTriggerEnter(Collider other){
        //Debug.Log("TriggerEnter: " + other.tag);
        if(groundie.IndexOf("|" + other.tag + "|") >=0){
            //Debug.Log("You're grounded");
            isGrounded = true;
            if(BackToGround != null) BackToGround.Invoke();
        } /*else if (deathie.IndexOf("|"+other.tag+"|") >= 0){
            if(DeathTouch != null) DeathTouch.Invoke();
        }*/ else if(switchie.IndexOf("|"+other.tag+"|") >= 0){
            if(NearSwitch != null) NearSwitch.Invoke();
        }


    }
    private void OnTriggerExit(Collider other){
        //Debug.Log("TriggerExit: " + other.tag);
        if(groundie.IndexOf("|" + other.tag + "|") >=0){
            //Debug.Log("Floating in the air");
            isGrounded = false;
        } else if(switchie.IndexOf("|"+other.tag+"|") >= 0){
            if(AwayFromSwitch != null) AwayFromSwitch.Invoke();
        }
    }
    public void JumpAnimStarted(){
        //Debug.Log("Whoa");
        if(OffTheGround != null) OffTheGround.Invoke();
    }

    public void DeathAnimEnd(){
        if(DeathAnimationEnd != null) DeathAnimationEnd.Invoke();

    }

    public void SwitchAnimEnd(){
        if(SwitchAnimationEnd != null) SwitchAnimationEnd.Invoke();
    }

    public void StandUpAnimEnd(){
        if(StandUpAnimationEnd != null) StandUpAnimationEnd.Invoke();
    }
}
