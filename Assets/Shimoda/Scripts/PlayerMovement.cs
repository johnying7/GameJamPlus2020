using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // just a small change
    public float speed;
    public float jumpForce;
    public float jumpTime;
    private bool movingRight = false;
    private float timer = 0.0f;
    private Rigidbody myRigidbody;
    private Transform character;
    private PlayerTouch playerTouch;
    private Animator animator;
    private bool alive;
    private bool switchCommand = false;
    private bool punching = false;

    // Start is called before the first frame update
    void Start()
    {
        character = transform.Find("Character");
        myRigidbody = character.GetComponent<Rigidbody>();
        playerTouch = character.GetComponent<PlayerTouch>();
        animator = character.GetComponent<Animator>();
        if(speed <= 0) speed = 1f;
        if(jumpForce <= 0) jumpForce = 8f;
        if(jumpTime <= 0) jumpTime = 0.3f;
        // Yet another small change
        timer = jumpTime + 1;
        alive = true;
        playerTouch.BackToGround.AddListener(BackFromJump);
        playerTouch.OffTheGround.AddListener(JumpStartForce);
        //playerTouch.DeathTouch.AddListener(Death); -> relegated to Game Manager 
        playerTouch.NearSwitch.AddListener(NearSwitch);
        playerTouch.AwayFromSwitch.AddListener(AwayFromSwitch);
        playerTouch.StandUpAnimationEnd.AddListener(RegainMovement);
        playerTouch.PunchAnimationEnd.AddListener(RegainPunch);
    }
    void Update()
    {
        if(alive){
            MoveHorizontal();
            Jump();
            MoveSwitch();
            Punch();
        } 
    }

    void Punch(){
        //if(Input.GetButton("Punchy") && !punching){
            
        //}
    }

    void RegainPunch(){
        punching = false;
    }
    void MoveHorizontal(){
        float direction = -Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if(direction != 0){
            if (direction > 0 && ! movingRight){
                movingRight = true;
                character.Rotate(new Vector3(0,180,0));
            }
            if (direction < 0 && movingRight){
                movingRight = false;
                character.Rotate(new Vector3(0,180,0));
            }
            character.Translate(new Vector3(0, 0, Mathf.Abs(direction)));
        }
        //Debug.Log("Speed " + Mathf.Abs(direction/Time.deltaTime));
        animator.SetFloat("Speed", Mathf.Abs(direction/Time.deltaTime));
    }

    void Jump(){
        if(Input.GetButton("Jump") && playerTouch.Check() && timer >= jumpTime){
            //
            timer = 0.0f;
            // Triggers jump Animation
            animator.SetBool("Jumping",true);
            animator.SetTrigger("InitJump");
        }
        if(timer <= jumpTime){
            timer += Time.deltaTime;
        }
    }

    public void JumpStartForce(){
        //Debug.Log("Jump Start Force");
        myRigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    void BackFromJump(){
        if(alive){
            animator.SetBool("Jumping",false);
            animator.SetTrigger("EndJump");
        }
    }

    public void Death(){
        if (alive)
        {
            animator.SetFloat("Speed", 0);
            animator.SetTrigger("Death");
            Debug.Log("Executing death method.");
            alive = false;
        }
    }

    public void Ressurect(){
        Debug.Log("Playing standUp animation");
        animator.SetTrigger("StandUp");
    }

    public void RegainMovement(){
        Debug.Log("Regain Movement after respawn");
        animator.SetTrigger("BackToAction");
        alive = true;
    }


    void MoveSwitch(){
        if(switchCommand && Input.GetButton("Submit")){
            animator.SetTrigger("Switch");
        }
    }

    void NearSwitch(){
        switchCommand = true;
    }
    void AwayFromSwitch(){
        switchCommand = false;
    }

}
