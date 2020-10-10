using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrapController : MonoBehaviour
{
    public GameObject playerParentObject;
    // Start is called before the first frame update
    void Start()
    {
        if (playerParentObject == null)
        {
            Debug.LogError("Must set player parent object.");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Trap")
        {
            killPlayer();
        }
    }

    private void killPlayer()
    {
        Debug.LogWarning("Implement player death actions in player manager.");
    }
}
