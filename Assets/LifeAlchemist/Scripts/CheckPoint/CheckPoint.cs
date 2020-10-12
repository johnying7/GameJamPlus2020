using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Vector3 respawnPosition;
    public void initializeRespawnPosition(Vector3 position)
    {
        respawnPosition = position;
        Debug.Log("Initializing respawn position to: " + position);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "PlayerBodyTrigger")
        {
            GameObject.FindWithTag("GameController").GetComponent<GameManager>().setRespawnPosition(respawnPosition);
            Debug.Log("Moving/Respawning player to: " + respawnPosition);
        }
    }
}
