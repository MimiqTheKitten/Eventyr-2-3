using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerupDoer : MonoBehaviour
{
    [SerializeField] int powerUpID;
    [SerializeField] int maxID = 10;
    
    //BulletPowerup Variables
    public float bulletSpeed = 10;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y+1,transform.position.z);
        //picking powerup
        powerUpID = Random.Range(0, maxID);
        Renderer cubeRenderer = GetComponent<Renderer>();
        
        switch (powerUpID)
        {

            case 0:
                cubeRenderer.material.color = Color.white;
                //Debug.Log("Color 0");
                break;
            case 1:
                cubeRenderer.material.color = Color.green;
                //Debug.Log("Color 1");
                break;
            case >1:
                cubeRenderer.material.color = Color.red;
                //Debug.Log("Color >1");
                break;
            default:
                break;
        }
    }

    public void Use(GameObject user)
    {
        //Debug.Log("used");
        //Do powerup
        switch (powerUpID)
        {
            case 0:
                //powerup 0 Jetpack
                user.GetComponent<PlayerMovement>().Jetpack();
                //Debug.Log(user.name + " used Jetpack powerup");
                break;

            case 1:
                //powerup 1 Clone
                Instantiate(user,user.transform.position,user.transform.rotation);
                //Making user the clone
                user.tag = "Clone";
                user.GetComponent<Renderer>().material.color = Color.grey;
                user.name = "Clone";
                break;

            case >1:
                //powerup >1 Bullet

                GameObject SpawnedBullet = Instantiate(bulletPrefab, user.transform.position, user.transform.rotation);
                Rigidbody rbOnBullet = SpawnedBullet.GetComponent<Rigidbody>();
                SpawnedBullet.GetComponent<HorizontalBullet>().user = user;
                
                rbOnBullet.velocity = user.transform.forward * bulletSpeed;
                Debug.Log("THIS HERE IS " + user.transform.forward);
                //if (ifFacingLeft == true)
                //{
                    //rbOnBullet.velocity = user.transform.right * bulletSpeed;
                    //rbOnBullet.velocity = -Camera.main.transform.right * bulletSpeed;
                    
                    //Debug.Log("Left");
                //}
                //else
                //{
                    //Debug.Log("Right");
                    //rbOnBullet.velocity = -user.transform.right * bulletSpeed;
                    //rbOnBullet.velocity = -Camera.main.transform.right * bulletSpeed;
                //}

                //Debug.Log("0");
                break;


            default:
                Destroy(gameObject);
                break;
        }
        Destroy(gameObject);
    }
}
