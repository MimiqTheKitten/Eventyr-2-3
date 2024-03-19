using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBullet : MonoBehaviour
{
    public GameObject user;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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


        Debug.Log("Destroyed by " + other.gameObject.name);
        Destroy(gameObject);
    }
}
