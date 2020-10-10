using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraPatch : MonoBehaviour
{
    public Transform cameraObject;
    public Transform characterObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cameraObject.transform.localPosition = new Vector3(-2, characterObject.transform.position.y, 0);
    }
}
