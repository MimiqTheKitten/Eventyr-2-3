using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] GameObject powerup;
    [SerializeField] float resetTimer = 10;
    float timer;

    private void Start()
    {
        
    }
    private void Update()
    {
        //stopping the timer
        if (timer <= -2) return;
        //checking if timer is over
        if(timer <= 0)
        {
            //reactivating objects
            gameObject.GetComponent<BoxCollider>().GetComponent<BoxCollider>().enabled = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        //timer
        timer -= Time.deltaTime;
    }
    public void Activate(GameObject player)
    {
        //Debugging who and what
        Debug.Log(gameObject.name + " activaed by " + player.name);
        //Give Player powerup and childing it
        Instantiate(powerup,player.transform);
        //Deactivate object
        gameObject.GetComponent<BoxCollider>().GetComponent<BoxCollider>().enabled = false; 
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        //start timer
        timer = resetTimer;
    }
}
