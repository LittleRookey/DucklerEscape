using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioClip firstAudioClip;
    public AudioClip secondAudioClip;
    private AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(firstAudioClip, .35f);
        audio.clip = secondAudioClip;
        audio.PlayDelayed(firstAudioClip.length);
        Debug.Log(firstAudioClip.length);
    }

    
    // Update is called once per frame
    void Update () {
        
	}
}
