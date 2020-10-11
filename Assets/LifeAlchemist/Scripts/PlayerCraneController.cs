using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCraneController : MonoBehaviour
{
    private Collider other;
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
            other.GetComponent<CraneController>().setPlayerPlaneController(this);
            this.other = other;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Crane")
        {
            other.GetComponent<CraneController>().setPlayerPlaneController(null);
            this.other = null;
        }
    }
    
    public void detachPlayerFromCrane()
    {
        this.transform.parent.parent = null;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.transform.parent.GetComponent<PlayerMovement>().enabled = true;
        this.GetComponent<PlayerTouch>().enabled = true;
    }

    public void attachPlayerToCrane()
    {
        if (other == null)
        {
            return;
        }
        this.transform.parent.parent = other.transform;
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.parent.GetComponent<PlayerMovement>().enabled = false;
        this.GetComponent<PlayerTouch>().enabled = false;
    }
}
