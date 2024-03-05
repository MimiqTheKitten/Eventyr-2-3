using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDoer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Pick random powerup
    }

    public void Use()
    {
        Debug.Log("used");
        //Do powerup
        Destroy(gameObject);
    }
}
