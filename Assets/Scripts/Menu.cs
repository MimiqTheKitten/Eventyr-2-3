using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public void OnPlayButton ()
    {
        SceneManager.LoadScene(1); //det behøver egentlig ikke være 1 den er sat til, det er bare vigtigt at den scene vi gerne vil ændre til's 'ID' inde på build settings er det samme som det der står her
    }
    public void OnQuitButton ()
    {
        Application.Quit();
        Debug.Log("quitting");
    }
}
