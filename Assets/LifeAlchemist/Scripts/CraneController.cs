using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    public float timeToDropObject = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Crane")
        {
            this.transform.parent.parent = other.transform;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.parent.GetComponent<PlayerMovement>().enabled = false;
            this.GetComponent<PlayerTouch>().enabled = false;
        }
    }
    
    private void returnCharacterControl()
    {
        this.transform.parent.parent = null;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.transform.parent.GetComponent<PlayerMovement>().enabled = true;
        this.GetComponent<PlayerTouch>().enabled = true;
    }
}
