using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpike : MonoBehaviour
{
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
        if(other.GetComponent<PlayerMovement>() != null)
        {
            Debug.Log(other.name + "has died to spikes");
            other.GetComponent<PlayerMovement>().PlayerDeath();
        }
    }
}
