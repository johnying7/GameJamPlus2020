using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BodyDetector : MonoBehaviour
{
    public UnityEvent EnterSunlight;
    public UnityEvent LeaveSunlight;
    public UnityEvent NearSwitch;
    public UnityEvent AwayFromSwitch;
    public string[] switchTags;
    public string sunlightTag;
    private string switchie;
    void Start()
    {
        if(EnterSunlight == null) EnterSunlight = new UnityEvent();
        if(LeaveSunlight == null) LeaveSunlight = new UnityEvent();
        if(NearSwitch == null) NearSwitch = new UnityEvent();
        if(AwayFromSwitch == null) AwayFromSwitch = new UnityEvent();
        foreach(string sth in switchTags){
            switchie +=  "|" + sth + "|";
        }

    }
    private void OnTriggerEnter(Collider other){
        //Debug.Log("TriggerEnter: " + other.tag);
         if(switchie.IndexOf("|"+other.tag+"|") >= 0){
            if(NearSwitch != null) NearSwitch.Invoke();
        }else if(other.tag.Equals(sunlightTag)){
            if(EnterSunlight != null) EnterSunlight.Invoke();
        }


    }
    private void OnTriggerExit(Collider other){
        //Debug.Log("TriggerExit: " + other.tag);
        if(switchie.IndexOf("|"+other.tag+"|") >= 0){
            if(AwayFromSwitch != null) AwayFromSwitch.Invoke();
        } else if(other.tag.Equals(sunlightTag)){
            if(LeaveSunlight != null) LeaveSunlight.Invoke();
        }
    }

}
