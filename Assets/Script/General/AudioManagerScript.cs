using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    private static AudioClip fireExtuingishSound;
    private static List<AudioClip> wooshSounds;
    private static List<AudioClip> fireSounds;
    private static AudioClip meteorSound;
    private static List<AudioClip> deathSounds;
    private static AudioClip healSound;
    static AudioSource src;    

    // Start is called before the first frame update
    void Start()
    {
        fireExtuingishSound = Resources.Load<AudioClip>("Sound/extinguish2");

        wooshSounds = new List<AudioClip>();
        wooshSounds.Add(Resources.Load<AudioClip>("Sound/woosh1"));
        wooshSounds.Add(Resources.Load<AudioClip>("Sound/woosh2"));
        wooshSounds.Add(Resources.Load<AudioClip>("Sound/woosh3"));
        
        fireSounds = new List<AudioClip>();
        fireSounds.Add(Resources.Load<AudioClip>("Sound/fire1"));
        fireSounds.Add(Resources.Load<AudioClip>("Sound/fire2"));
        
        meteorSound = Resources.Load<AudioClip>("Sound/meteor2");

        deathSounds = new List<AudioClip>();
        deathSounds.Add(Resources.Load<AudioClip>("Sound/deathSound1"));
        deathSounds.Add(Resources.Load<AudioClip>("Sound/deathSound2"));

        healSound = Resources.Load<AudioClip>("Sound/healSound");

        src = GetComponent<AudioSource>();        
    }

    public static void PlaySound(string name)
    {
        var rng = new System.Random();
        src.pitch = Random.Range(0.8f, 1.3f);
        switch (name)
        {
            case "extinguish":                
                src.PlayOneShot(fireExtuingishSound);
                break;
            case "woosh":                
                src.PlayOneShot(wooshSounds[rng.Next(wooshSounds.Count)]);
                break;
            case "fire":
                src.PlayOneShot(fireSounds[rng.Next(fireSounds.Count)]);
                break;
            case "meteor":
                src.PlayOneShot(meteorSound);
                break;
            case "death":
                src.PlayOneShot(deathSounds[rng.Next(deathSounds.Count)]);
                break;
            case "heal":
                src.PlayOneShot(healSound);
                break;
        }
    }
}
