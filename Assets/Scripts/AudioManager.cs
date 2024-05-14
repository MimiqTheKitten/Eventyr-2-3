using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    [SerializeField] string mainTheme;
    [SerializeField] string battleTheme;

    public static AudioManager instance;

    [SerializeField] int[] battleScenes;
    int scene;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(this);

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }            

    }
    private void Start()
    {
        PlayTheme();
    }
    public void play(string name)
    {
        Sound s =Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Couldn't find sound: " + name);
            return;
        }
        Debug.Log("playing "+ name);
        s.source.Play();
    }
    void PlayTheme()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 0 && mainTheme != null)
        {
            play(mainTheme);
        }
        if(battleScenes.Contains(scene) && battleTheme != null)
        {
            play(battleTheme);
        }
    }
}
