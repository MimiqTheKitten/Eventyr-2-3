using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeTeleporter : MonoBehaviour
{
    Rigidbody rb;
    float screenEdgeX = 11;
    float screenEdgeY = 6;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > screenEdgeX)
        {
            transform.Translate(Vector3.left * screenEdgeX * 2, Space.World);
        }
        
        if (transform.position.x < -screenEdgeX)
        {
            transform.Translate(Vector3.right * screenEdgeX * 2, Space.World);
        }



        if (transform.position.y > screenEdgeY)
        {
            transform.Translate(Vector3.down * screenEdgeY * 2, Space.World);
        }
        
        if (transform.position.y < -screenEdgeY)
        {
            transform.Translate(Vector3.up * screenEdgeY * 2, Space.World);
        }
    }
}
