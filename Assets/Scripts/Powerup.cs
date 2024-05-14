using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] GameObject powerup;
    [SerializeField] float resetTimer = 10;
    float timer;

    private void Update()
    {
        //stopping the timer
        if (timer <= -2) return;
        //checking if timer is over
        if(timer <= 0)
        {
            //reactivating objects
            GameObjectActive(true);
        }
        //timer
        timer -= Time.deltaTime;
    }
    public void Activate(GameObject player)
    {
        //Debugging who and what
        //Debug.Log(gameObject.name + " activaed by " + player.name);
        //Give Player powerup and childing it
        Instantiate(powerup,player.transform);
        //Deactivate object
        GameObjectActive(false);
        //start timer
        timer = resetTimer;
    }
    private void GameObjectActive(bool state)
    {
        gameObject.GetComponent<BoxCollider>().GetComponent<BoxCollider>().enabled = state;
        gameObject.GetComponent<MeshRenderer>().enabled = state;
    }
}
