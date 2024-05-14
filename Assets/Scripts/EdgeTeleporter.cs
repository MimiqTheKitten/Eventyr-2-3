using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeTeleporter : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float screenEdgeX = 11;
    [SerializeField] float screenEdgeY = 0;
    Vector3 teleport
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
            Transform.Translate(new Vector3(-screenEdgeX * 2, 0, 0));
        }
        
        /*if (transform.position.x < ScreenEdgeX)
        {
            transform.position.x += ScreenEdgeX * 2;
        }*/
    }
}
