using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    public UnityEvent myUnityEvent;

    private bool canActivate = false;

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && canActivate)
        {
            Debug.Log("activating switch");
            myUnityEvent.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {
            canActivate = false;
        }
    }
}
