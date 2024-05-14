using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using System.Threading;

public class WinManager : MonoBehaviour
{
    GameObject[] players;
    [SerializeField] int loadScene = 0;
    float timer = 3f;
    bool doTimer;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("found " + players.Length + " players");
    }

    // Update is called once per frame
    void Update()
    {
        if (doTimer)
        {
            timer -= Time.deltaTime;
        }
        players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length <= 1)
        {
            FindObjectOfType<AudioManager>().play("WinSound");
            Debug.Log("Winner found");
            
                 
        }
        if(timer <= 0)
        {
            SceneManager.LoadScene(loadScene);
        }

    }

}
