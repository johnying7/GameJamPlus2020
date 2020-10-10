using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // just a small change
    public float speed;
    public float jumpForce;
    public float jumpTime;
    private bool movingRight = true;
    private float timer = 0.0f;
    private Rigidbody myRigidbody;
    private Transform character;
    private GroundContact ground;

    // Start is called before the first frame update
    void Start()
    {
        character = transform.Find("Character");
        myRigidbody = character.GetComponent<Rigidbody>();
        ground = character.GetComponent<GroundContact>();
        if(speed <= 0) speed = 1f;
        if(jumpForce <= 0) jumpForce = 8f;
        if(jumpTime <= 0) jumpTime = 0.3f;
        // Yet another small change
        timer = jumpTime + 1; 
    }

    void MoveHorizontal(){
        float direction = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if(direction != 0){
            if (direction > 0 && ! movingRight){
                movingRight = true;
                character.Rotate(new Vector3(0,180,0));
            }
            if (direction < 0 && movingRight){
                movingRight = false;
                character.Rotate(new Vector3(0,180,0));
            }
            transform.Translate(new Vector3(0, 0, direction));
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        Debug.Log("Timer: "+ timer);
        if(Input.GetButton("Jump") && ground.Check() && timer >= jumpTime){
            myRigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            timer = 0.0f;
        }
        if(timer <= jumpTime){
            timer += Time.deltaTime;
        }
    }

}
