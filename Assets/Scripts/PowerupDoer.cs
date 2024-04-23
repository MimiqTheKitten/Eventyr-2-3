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
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y+1,transform.position.z);
        //picking powerup
        powerUpID = Random.Range(0, maxID);
        var cubeRenderer = gameObject.GetComponent<Renderer>();

        // change color to red
        cubeRenderer.material.SetColor("_Color", Color.red);
        /*
        switch (powerUpID)
        {
            case 0:
                gameObject.GetComponent<Renderer>().material.SetColor("_color",Color.blue);
                Debug.Log("Color 1");
                break;
            case 1:
                gameObject.GetComponent<Renderer>().material.SetColor("_color", Color.blue);
                Debug.Log("Color 2");
                break;
            case 2:
                GetComponent<Renderer>().material.SetColor("_color", Color.blue);
                Debug.Log("Color 3");
                break;
            default:

                break;
        }*/
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
                user.GetComponent<PlayerMovement>().Jetpack();
                Debug.Log(user.name + " used Jetpack powerup");
                break;

            default:
                break;
        }
        Destroy(gameObject);
    }
}
