using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioClip fireExtuingishSound;
    static AudioSource src;

    // Start is called before the first frame update
    void Start()
    {
        fireExtuingishSound = Resources.Load<AudioClip>("Sound/extinguish");
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
        }
    }
}
