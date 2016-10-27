using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour {
    //Same idea as toggle music. Read there for explanation.
    public AudioSource menuSound;
    public Toggle SoundToggle;
    public Slider SoundVolume;

    public void Slider_Changed(float newVolume) {
        menuSound.volume = newVolume;
    }

    public void Toggle_Changed(bool SoundToggle) {
        SoundVolume.interactable = SoundToggle;
        if (SoundToggle == true)
            menuSound.mute = false;
        else
            menuSound.mute = true;
    }
}
