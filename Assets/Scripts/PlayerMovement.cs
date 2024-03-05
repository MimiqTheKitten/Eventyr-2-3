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
    private float horizontalInput;
    private float verticalInput;
    private Vector3 movedirection;
    [SerializeField] float jumpCheckDis;
    [SerializeField] LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        //getting Rigidbody
        rb =GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement input
        horizontalInput = Input.GetAxis("Horizontal");
        movedirection = new Vector3(horizontalInput * speed, rb.velocity.y, 0);
        //jumping
        if(Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //check for child/powerup
            if(transform.childCount != 0)
            {
                Debug.Log("has child " + transform.childCount);
                GetComponentInChildren<PowerupDoer>().Use();
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
            //Activating powerup and giving the player object
            collision.gameObject.GetComponent<Powerup>().Activate(gameObject);
        }
        else return;
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
