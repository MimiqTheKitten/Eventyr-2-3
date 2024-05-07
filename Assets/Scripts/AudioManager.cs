using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    [SerializeField] string theme;

    public static AudioManager instance;
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
        DontDestroyOnLoad(this);

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
        if(theme != null)
        {
            play(theme);
        }
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
}
