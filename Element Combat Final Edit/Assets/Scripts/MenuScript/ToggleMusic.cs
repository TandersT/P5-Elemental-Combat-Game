using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour {
    //Adds a slider & toggle for music volume/muting. Can be put on any gameobject, and then that gameobject is reffered to on slider/toggle
    public AudioSource menuMusic;
    public Toggle musicToggle;
    public Slider musicVolume;

    //Changes volume according to slider
    public void Slider_Changed(float newVolume) {
        menuMusic.volume = newVolume;
    }

    //Makes music mutable through toggle
    public void Toggle_Changed(bool musicToggle) {
        musicVolume.interactable = musicToggle;
        if (musicToggle == true)
            menuMusic.mute = false;
        else
            menuMusic.mute = true;
    }
}
