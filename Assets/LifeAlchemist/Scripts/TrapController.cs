using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public bool startTrapOn = true;
    public float trapOnDuration = 2.0f;
    public float trapOffDuration = 0;
    public GameObject trapGameObject;

    private bool isTrapOn;
    private float currentTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        isTrapOn = startTrapOn ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (isTrapOn && currentTime > trapOnDuration)
        {
            isTrapOn = false;
            currentTime = 0;
            trapGameObject.SetActive(false);
        }
        
        if (!isTrapOn && currentTime > trapOffDuration)
        {
            isTrapOn = true;
            currentTime = 0;
            trapGameObject.SetActive(true);
        }
    }
}
