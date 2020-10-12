using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    private PlayerCraneController playerCraneController;
    private bool isPlayerAttached = false;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent.GetComponent<MovingPlatform>().setCraneController(this);
    }

    public void setPlayerPlaneController(PlayerCraneController playerCraneController)
    {
        this.playerCraneController = playerCraneController;
    }

    public void attachPlayer()
    {
        if (playerCraneController != null)
        {
            isPlayerAttached = true;
            playerCraneController.attachPlayerToCrane();
        }
    }

    public void detachPlayer()
    {
        if (playerCraneController != null)
        {
            isPlayerAttached = false;
            playerCraneController.detachPlayerFromCrane();
        }
    }

    public void attachAndDetachPlayer()
    {
        if (isPlayerAttached)
        {
            detachPlayer();
        }
        else
        {
            attachPlayer();
        }
    }
}
