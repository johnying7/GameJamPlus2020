using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this to the player.
/// </summary>
public class PlatformAttachment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (this.transform.parent.parent.tag != "Player")
        {
            Debug.LogError("Parent of parent tag not set to Player.");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Platform")
        {
            this.transform.parent.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Platform")
        {
            this.transform.parent.parent = null;
        }
    }
}
