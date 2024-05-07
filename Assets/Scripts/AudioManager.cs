using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; 
    void Awake()
    {
        foreach (var sound in sounds)
            sound.source = gameObject.AddComponent<AudioSource>();
        sound
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
