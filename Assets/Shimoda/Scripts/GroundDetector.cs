using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundDetector : MonoBehaviour
{
    public string[] groundTags;
    private bool isGrounded = true;
    private string groundie;
    public UnityEvent BackToGround;

    // Start is called before the first frame update
    void Start()
    {
        if(BackToGround == null) BackToGround = new UnityEvent();
        foreach(string gnd in groundTags){
            groundie += "|" + gnd + "|"; 
        }
    }
    public bool Check(){
        return isGrounded;
    }

    private void OnTriggerEnter(Collider other){
        if(groundie.IndexOf("|" + other.tag + "|") >=0){
            //Debug.Log("You're grounded");
            isGrounded = true;
            if(BackToGround != null) BackToGround.Invoke();
        }
    }
    private void OnTriggerExit(Collider other){
        if(groundie.IndexOf("|" + other.tag + "|") >=0){
            //Debug.Log("Floating in the air");
            isGrounded = false;
        } 
    }


}
