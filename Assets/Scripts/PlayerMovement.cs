using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    //GameObject winManager;

    [SerializeField] float speed = 15.0f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float jetpackForce = 5f;
    [SerializeField] float jumpCheckDis;

    [SerializeField] string playerMoveAxis = "Horizontal 1";// Horizontal 1, Horizontal 2, Horizontal 3, Horizontal 4
    [SerializeField] string playerMoveJump = "w";//w, up, [8], j
    [SerializeField] string playerMovePowerup = "s";//s, down, [5], n

    private float horizontalInput;
    private float lookWay;
    private Vector3 movedirection;
    
    bool jetpackActive = false;
    [SerializeField] float jetpackTimer;
    float jetpackMax = 10;

    
    [SerializeField] LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        //getting Rigidbody
        rb = GetComponent<Rigidbody>();
        if(transform.childCount > 0 && transform.GetChild(0)!=null)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //jetpack timer
        if (jetpackActive)
        {
            if(jetpackTimer <= 0)
            {
                jetpackActive = false;
            }
            jetpackTimer -= Time.deltaTime;
        }

        //movement input
        horizontalInput = Input.GetAxis(playerMoveAxis);
        if(horizontalInput > 0) //if player is moving right,
        {
            gameObject.transform.rotation = Quaternion.Euler(0f,90f,0f); //make player face right
            
        }
        else if(horizontalInput < 0) //if player is moving left,
        {
            gameObject.transform.rotation = Quaternion.Euler(0f,-90f,0f); //make player face left

        }

        movedirection = new Vector3(horizontalInput * speed, rb.velocity.y, 0);

        //jumping
        if(Input.GetKeyDown(playerMoveJump) && Grounded() ||/*Jetpack powerup*/ Input.GetKeyDown(playerMoveJump) && jetpackActive)
        {
            Jump();
        }
        //Use powerup
        if (Input.GetKeyDown(playerMovePowerup))
        {
            //check for powerup
            if(transform.childCount != 0)
            {
                PlaySound("UseSound");
                //Debug.Log(gameObject.name + "has child " + transform.childCount);
                GetComponentInChildren<PowerupDoer>().Use(this.gameObject);
            }
        }
    }
    private void FixedUpdate()
    {
        //movement
        rb.velocity = movedirection;
        //reset velocity
        if (horizontalInput == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        
            
            
        /*//ground debugging
        if (Grounded())
            Debug.Log("Ground");
        else Debug.Log("Not grounded");*/
    }
    void Jump()
    {
        PlaySound("JumpSound");
        if(!jetpackActive) {
            rb.AddForce(transform.up * jumpForce);
        } else
        {
            rb.AddForce(transform.up * jetpackForce);
        }
        
    }
    public void Jetpack()
    {
        jetpackTimer = jetpackMax;
        jetpackActive = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Checking for powerups
        if (other.gameObject.tag == "Powerup")
        {
            //Debug.Log("Powerup");
            //Activating powerup and giving the player object info
            other.gameObject.GetComponent<Powerup>().Activate(gameObject);
        }
        else return;
    }
    public void PlayerDeath()
    {
        PlaySound("DeathSound");
        Destroy(gameObject);
    }

    bool Grounded()
    {
        //checking if player is "near" the ground
        if(Physics.BoxCast(GetComponent<Collider>().bounds.center, transform.localScale * 0.5f, -transform.up, transform.rotation, jumpCheckDis, groundLayer))
        {
            return true;
        }
        else return false;
    }
    private void OnDrawGizmos()
    {
        //drawing the box for the groundcheck
        Gizmos.DrawWireCube(GetComponent<Collider>().bounds.center + -transform.up * jumpCheckDis, transform.localScale);
    }
    void PlaySound(string name)
    {
        FindObjectOfType<AudioManager>().play(name);
    }
}
