using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDoer : MonoBehaviour
{
    [SerializeField] int powerUpID;
    [SerializeField] int maxID = 2;

    //BulletPowerup Variables
    public float BulletSpeed;
    public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //picking powerup
        powerUpID = Random.Range(0, maxID);
    }

    public void Use(GameObject user)
    {
        Debug.Log("used");
        //Do powerup
        switch(powerUpID) 
            {
            case 0:
                //powerup 0
                Debug.Log("0");

                    break; 
            
            case 1:
                //powerup 1
                Debug.Log("2");
                break;

            default:
                break;
            }
        Destroy(gameObject);
    }
}
