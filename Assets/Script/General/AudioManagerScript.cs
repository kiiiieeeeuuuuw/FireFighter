using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioClip fireExtuingishSound;
    public static List<AudioClip> wooshSounds;
    static AudioSource src;

    // Start is called before the first frame update
    void Start()
    {
        fireExtuingishSound = Resources.Load<AudioClip>("Sound/extinguish");
        wooshSounds = new List<AudioClip>();
        wooshSounds.Add(Resources.Load<AudioClip>("Sound/woosh1"));
        wooshSounds.Add(Resources.Load<AudioClip>("Sound/woosh2"));
        wooshSounds.Add(Resources.Load<AudioClip>("Sound/woosh3"));


        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string name)
    {
        switch (name)
        {
            case "extinguish":                
                src.PlayOneShot(fireExtuingishSound);
                break;
            case "woosh":
                var rng = new System.Random();
                src.PlayOneShot(wooshSounds[rng.Next(wooshSounds.Count)]);
                break;
        }
    }
}
