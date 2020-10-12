using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform initialRespawnPosition;
    public Transform playerTransform;
    private Vector3 respawnPosition;
    private Transform characterTransform;
    private PlayerTouch playerTouch;
    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        if (playerTransform == null)
        {
            Debug.LogError("Must have a player in the scene.");
        }
        playerMovement = playerTransform.GetComponent<PlayerMovement>();
        characterTransform = playerTransform.Find("Character");
        // if (playerTransform.Find("Character").tag != "Player")
        // {
        //     characterTransform.tag = "Player";
        // }
        playerTouch = characterTransform.GetComponent<PlayerTouch>();
        playerTouch.DeathAnimationEnd.AddListener(respawnPlayer);
        respawnPosition = initialRespawnPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void respawnPlayer(){
        //respawn player here
        playerTransform.position = respawnPosition;
        characterTransform.position = respawnPosition;
        Debug.Log("Respawn position: " + respawnPosition);
        playerMovement.Ressurect();
    }

    public void respawnMovePlayer()
    {
        playerMovement.Death();
        Debug.Log("Player is in dying mode.");
    }

    public void setRespawnPosition(Vector3 position)
    {
        Debug.Log("Setting game manager respawn position: " + position);
        respawnPosition = position;
    }
}
