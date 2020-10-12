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
        Transform character = this.transform.parent;
        Transform player = character.parent;
        player.parent = null;
        character.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        character.GetComponent<PlayerTouch>().enabled = true;
    }

    public void attachPlayerToCrane()
    {
        if (other == null)
        {
            return;
        }
        Transform character = this.transform.parent;
        Transform player = character.parent;
        player.parent = other.transform;
        character.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<PlayerMovement>().enabled = false;
        character.GetComponent<PlayerTouch>().enabled = false;
    }
}
