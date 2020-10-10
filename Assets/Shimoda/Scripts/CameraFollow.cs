using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float characterGap;
    public Transform character;
    // Start is called before the first frame update
    void Start()
    {
        if(characterGap <=0) characterGap = 4;
    }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = this.transform.localPosition;
        currentPosition.y = character.localPosition.y + characterGap;
        currentPosition.z = character.localPosition.z;
        this.transform.localPosition = currentPosition;
    }
}
