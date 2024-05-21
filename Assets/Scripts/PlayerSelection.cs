using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    public void On2Players()
    {
        SceneManager.LoadScene(1);
    }

    public void On3Players ()
    {
        SceneManager.LoadScene(2);
    }

    public void On4Players ()
    {
        SceneManager.LoadScene(3);
    }
}
