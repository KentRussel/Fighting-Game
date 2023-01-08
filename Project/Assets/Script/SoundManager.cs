using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, playerWalkSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
         playerHitSound = Resources.Load<AudioClip>("playerSlash");
         playerWalkSound = Resources.Load<AudioClip>("playerRun");


         audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch(clip) {
            case "playerSlash":
            audioSrc.PlayOneShot (playerHitSound);
            break;
            case "playerRun":
            audioSrc.PlayOneShot (playerWalkSound);
            break;
        }
    }
}
