using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float speed = 15.0f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float jumpCheckDis;

    [SerializeField] string playerMoveAxis = "Horizontal 1";// Horizontal 1, Horizontal 2, Horizontal 3, Horizontal 4
    [SerializeField] string playerMoveJump = "space";//W, up, [8], j
    [SerializeField] string playerMovePowerup = "s";//s, down, [5], n

    private float horizontalInput;
    private float lookWay;
    private Vector3 movedirection;
    
    [SerializeField] LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        //getting Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement input
        horizontalInput = Input.GetAxis(playerMoveAxis);
        lookWay = Mathf.RoundToInt(Input.GetAxis(playerMoveAxis));
        switch(lookWay)
        {
            case -1:
                transform.localScale = new Vector3(-1f, 1f, 1f);
                break;

            case 1:
                transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            default:
                break;
        }

        movedirection = new Vector3(horizontalInput * speed, rb.velocity.y, 0);

        //jumping
        if(Input.GetKeyDown(playerMoveJump) && Grounded())
        {
            Jump();
        }
        if (Input.GetKeyDown(playerMovePowerup))
        {
            //check for powerup
            if(transform.childCount != 0)
            {
                Debug.Log(gameObject.name + "has child " + transform.childCount);
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
        
            
            
        //ground debugging
        if (Grounded())
            Debug.Log("Ground");
        else Debug.Log("Not grounded");
    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpForce);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Checking for powerups
        if (collision.gameObject.tag == "Powerup")
        {
            //Debug.Log("Powerup");
            //Activating powerup and giving the player object info
            collision.gameObject.GetComponent<Powerup>().Activate(gameObject);
        }
        else return;
    }
    public void PlayerDeath()
    {
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
}
