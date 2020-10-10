using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this to the player.
/// </summary>
public class PlatformAttachment : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Platform")
        {
            this.transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Platform")
        {
            this.transform.parent = null;
        }
    }
}
