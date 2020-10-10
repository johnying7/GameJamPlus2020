using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = this.transform.localPosition;
        currentPosition.z = character.localPosition.z;
        this.transform.localPosition = currentPosition;
    }
}
