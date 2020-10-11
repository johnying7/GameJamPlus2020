using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public Transform respawnPoint;
    public CheckPoint dirtGroundCheckPoint;
    // Start is called before the first frame update
    void Start()
    {
        dirtGroundCheckPoint.initializeRespawnPosition(respawnPoint.position);
    }
}
