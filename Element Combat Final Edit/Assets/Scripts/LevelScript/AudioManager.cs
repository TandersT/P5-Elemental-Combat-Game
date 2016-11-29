using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource MenuMusic;
    //public AudioSource GameOverMusic;
    public AudioSource currentTrack;
    public AudioSource previousTrack;

    float walkingCycle = 0.5f;
    float walkingRate = 0.5f; //2 steps in a second

    public AudioSource sound;
    int number = 0;
    public AudioClip[] arrayAudioClips = new AudioClip[4];


    void Start() {
        PlayMusic(MenuMusic, true);
        currentTrack = MenuMusic;
        previousTrack = currentTrack;
    }
     //&& isWalking && grounded
    void FixedUpdate() {
        if (Time.time > walkingCycle) {
            walkingCycle = Time.time + walkingRate;
            walkingSound();
            number++;
        }
    }

    void walkingSound() {
        if (number > arrayAudioClips.Length - 2)
            number = 0;
        sound.clip = arrayAudioClips[number];
        sound.loop = false;
        sound.Play();

    }

    void PlayMusic(AudioSource track, bool loop) {
            previousTrack = currentTrack;
            FadeOut(previousTrack);
            currentTrack = track;
            FadeIn(currentTrack);
            currentTrack.loop = loop;
            currentTrack.Play();
    }

    public void FadeOut(AudioSource audio) {
        StartCoroutine(FadeOutCoroutine(audio));
    }

    private IEnumerator FadeOutCoroutine(AudioSource audio) {
        while (audio.isPlaying && audio.volume > 0.2f) {
            audio.volume -= 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
        audio.volume = 0f;
        audio.Stop();
    }

    public void FadeIn(AudioSource audio) {
        StartCoroutine(FadeInCoroutine(audio));
    }

    private IEnumerator FadeInCoroutine(AudioSource audio) {
        while (audio.isPlaying && audio.volume < (1f - 0.2f)) {
            audio.volume += 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
        audio.volume = 1f;
        audio.Stop();
    }
}
