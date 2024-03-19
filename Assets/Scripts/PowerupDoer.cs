using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerupDoer : MonoBehaviour
{
    [SerializeField] int powerUpID;
    [SerializeField] int maxID = 2;

    //BulletPowerup Variables
    public float bulletSpeed = 10;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //picking powerup
        powerUpID = Random.Range(0, maxID);
    }

    public void Use(GameObject user, bool ifFacingLeft)
    {
        Debug.Log("used");
        //Do powerup
        switch (powerUpID)
        {
            case 0:
                //powerup 0

                GameObject SpawnedBullet = Instantiate(bulletPrefab, user.transform.position, user.transform.rotation);
                Rigidbody rbOnBullet = SpawnedBullet.GetComponent<Rigidbody>();
                SpawnedBullet.GetComponent<HorizontalBullet>().user = user;

                if (ifFacingLeft == true)
                {
                    rbOnBullet.velocity = user.transform.right * bulletSpeed;
                }
                else
                {
                    rbOnBullet.velocity = -user.transform.right * bulletSpeed;
                }

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
