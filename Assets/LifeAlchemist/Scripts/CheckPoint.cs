using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            GameObject.FindWithTag("GameController").GetComponent<GameManager>().setRespawnPosition(this.transform.position);
        }
    }
}
