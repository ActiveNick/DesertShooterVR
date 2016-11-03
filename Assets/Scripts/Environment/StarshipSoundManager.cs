using UnityEngine;
using System.Collections;

public class StarshipSoundManager : MonoBehaviour {

    public AudioSource shipAudio;
    public AudioClip landingClip;
    public AudioClip thudClip;
    public AudioClip warpClip;

    private float originalVolume;

	// Use this for initialization
	void Start () {
        originalVolume = shipAudio.volume;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void PlayLandingSound()
    {
        // Change the clip to the firing clip and play it.
        shipAudio.volume = originalVolume;
        shipAudio.clip = landingClip;
        shipAudio.Play();
    }

    private void PlayThudSound()
    {
        // Change the clip to the firing clip and play it.
        shipAudio.volume = 1;
        shipAudio.clip = thudClip;
        shipAudio.Play();
    }

    private void PlayWarpSound()
    {
        // Change the clip to the firing clip and play it.
        shipAudio.volume = 1;
        shipAudio.clip = warpClip;
        shipAudio.Play();
    }
}
