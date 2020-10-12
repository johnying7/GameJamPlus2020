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
        if (other.tag == "PlayerBodyTrigger" && !canActivate)
        {
            Debug.Log("Arriving at switch");
            playerTouch = other.transform.parent.GetComponent<PlayerTouch>();
            playerTouch.SwitchAnimationEnd.AddListener(TriggerSwitchEvent);
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "PlayerBodyTrigger" && canActivate)
        {
            Debug.Log("Leaving switch");
            playerTouch.SwitchAnimationEnd.RemoveListener(TriggerSwitchEvent);
            playerTouch = null;
            canActivate = false;
        }
    }
}
