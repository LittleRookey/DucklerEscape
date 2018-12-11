using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour {

    public Slider volumeSlider;
    public AudioSource volumeAudio;

    private void Start()
    {
        volumeSlider.value = .5f;
    }
    private void Update()
    {
        volumeAudio.volume = volumeSlider.value;
    }
}
