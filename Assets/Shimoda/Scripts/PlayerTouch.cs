using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTouch : MonoBehaviour
{
    //public UnityEvent DeathTouch;
    public UnityEvent OffTheGround;
    public UnityEvent DeathAnimationEnd;
    public UnityEvent StandUpAnimationEnd;
    public UnityEvent SwitchAnimationEnd; 
    public UnityEvent PunchAnimationHit; 
    public UnityEvent PunchAnimationEnd; 

    void Start(){
        if(DeathAnimationEnd == null) DeathAnimationEnd = new UnityEvent();
        if(SwitchAnimationEnd == null) SwitchAnimationEnd = new UnityEvent();
        if(StandUpAnimationEnd == null) StandUpAnimationEnd = new UnityEvent();
        if(PunchAnimationHit == null) PunchAnimationHit = new UnityEvent();
        if(PunchAnimationEnd == null) PunchAnimationEnd = new UnityEvent();
        if(OffTheGround == null) OffTheGround = new UnityEvent();
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
    public void PunchAnimHit(){
        if(PunchAnimationHit != null) PunchAnimationHit.Invoke();

    }

    public void PunchAnimEnd(){
        if(PunchAnimationEnd != null) PunchAnimationEnd.Invoke();
    }

    public void JumpAnimStarted(){
        //Debug.Log("Whoa");
        if(OffTheGround != null) OffTheGround.Invoke();
    }

    
}
