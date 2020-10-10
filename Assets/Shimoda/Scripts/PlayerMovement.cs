using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // just a small change
    public float speed;
    bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        // Yet another small change
        
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if(direction != 0){
            if (direction > 0 && ! movingRight){
                movingRight = true;
                transform.Rotate(new Vector3(0,180,0));
            }
            if (direction < 0 && movingRight){
                movingRight = false;
                transform.Rotate(new Vector3(0,180,0));
            }
            transform.Translate(new Vector3(0, 0, Mathf.Abs(direction)));
        }

    }
}
