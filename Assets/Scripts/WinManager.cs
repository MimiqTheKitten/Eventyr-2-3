using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using System.Threading;

public class WinManager : MonoBehaviour
{
    GameObject[] players;
    [SerializeField] int loadScene = 0;
    [SerializeField] float timer = 3f;
    bool doTimer = false;
    bool winnerFound = false;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("found " + players.Length + " players");
    }

    // Update is called once per frame
    void Update()
    {     
        players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length <= 1 && !winnerFound)
        {
            FindObjectOfType<AudioManager>().play("WinSound");
            Debug.Log("Winner found");
            doTimer = true; 
            winnerFound = true;                 
        }
        if (doTimer)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            SceneManager.LoadScene(loadScene);
        }

    }

}
