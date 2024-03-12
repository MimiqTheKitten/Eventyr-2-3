using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDoer : MonoBehaviour
{
    [SerializeField] int powerUpID;
    [SerializeField] int maxID = 2;

    //BulletPowerup Variables
    public float bulletSpeed = 1;
    public GameObject bulletPrefab;

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

                GameObject SpawnedBullet = Instantiate(bulletPrefab, user.transform.position, user.transform.rotation);
                Rigidbody rbOnBullet = SpawnedBullet.GetComponent<Rigidbody>();
                rbOnBullet.velocity = user.transform.right * bulletSpeed;

                Debug.Log("0");

                    break; 
            
            case 1:
                //powerup 1
                Debug.Log("1");
                break;

            default:
                break;
            }
        Destroy(gameObject);
    }
}
