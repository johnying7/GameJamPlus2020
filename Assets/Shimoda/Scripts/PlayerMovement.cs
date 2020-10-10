using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // just a small change
    public float speed;
    public float jumpForce;
    private bool movingRight = true;
    private Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        var character = transform.Find("Character");
        myRigidbody = character.GetComponent<Rigidbody>();
        if(speed <= 0) speed = 1f;
        if(jumpForce <= 0) jumpForce = 0.4f;
        // Yet another small change
        
    }

    void MoveHorizontal(){
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

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        if(Input.GetButton("Jump")){
            myRigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

        }
    }
}
