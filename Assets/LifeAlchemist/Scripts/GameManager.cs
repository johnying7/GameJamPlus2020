using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform initialRespawnPosition;
    public Transform playerTransform;
    private Vector3 respawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Must set player transform in game manager.");
        }

        Transform characterTransform = playerTransform.Find("Character");
        if (playerTransform.Find("Character").tag != "Player")
        {
            characterTransform.tag = "Player";
        }
        respawnPosition = initialRespawnPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void respawnMovePlayer()
    {
        playerTransform.position = respawnPosition;
    }

    public void setRespawnPosition(Vector3 position)
    {
        respawnPosition = position;
    }
}
