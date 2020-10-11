using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    public UnityEvent myUnityEvent;

    private bool canActivate = false;

    private PlayerTouch playerTouch;

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetButtonDown("Submit") && canActivate)
        {
            playerTouch
        }*/
    }

    void TriggerSwitchEvent(){
        myUnityEvent.Invoke();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            playerTouch = other.GetComponent<PlayerTouch>();
            playerTouch.SwitchAnimationEnd.AddListener(TriggerSwitchEvent);
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {
            playerTouch.SwitchAnimationEnd.RemoveListener(TriggerSwitchEvent);
            playerTouch = null;
            canActivate = false;
        }
    }
}
