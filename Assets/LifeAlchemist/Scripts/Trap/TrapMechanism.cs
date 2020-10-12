using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMechanism : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "PlayerBodyTrigger")
        {
            killPlayer();
        }
    }

    private void killPlayer()
    {
        gameManager.respawnMovePlayer();
    }
}
