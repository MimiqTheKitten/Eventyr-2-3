using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class WinManager : MonoBehaviour
{
    GameObject[] players;
    [SerializeField] int loadScene = 0;

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
        if(players.Length <= 1)
        {
            Debug.Log("Winner found");
            SceneManager.LoadScene(loadScene);            
        }

    }

}
