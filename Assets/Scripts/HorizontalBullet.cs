using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBullet : MonoBehaviour
{
    public GameObject user;
    Rigidbody rb;

    void awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void update()
    {
        rb.AddForce(rb.velocity * 0.5f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == null || other.gameObject == user)
        {
            return;
        }

        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            other.gameObject.GetComponent<PlayerMovement>().PlayerDeath();
        }


        //Debug.Log("Destroyed by " + other.gameObject.name);
        Destroy(gameObject);
    }

}
