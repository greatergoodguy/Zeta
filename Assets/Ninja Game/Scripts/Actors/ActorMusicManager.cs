using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMusicManager : MonoBehaviour {

    /*
	 * 0 - Ninja Tune
	 * 1 - 
	 * 2 - 
	 * 3 - 
	 * 4 - 
	 * 5 - 
	 * 6 - 
	 * 7 - 
	 * 8 - 
	 * 9 - 
	 * 10 - 
	 * 11 - 
	 * 12 - 
	 * */

    public static ActorMusicManager I;

    private const float DEFAULT_FADE_DURATION = 3.0f;

    AudioSource[] audioClips;
    AudioSource activeAudioClip;

    void Awake() {
        I = this;
        audioClips = GetComponents<AudioSource>();
    }

    public void PlayInstant(int index, float volume = 1.0f, float startTimestamp = 0.0f) {
        activeAudioClip = audioClips[index];
        activeAudioClip.volume = volume;
        activeAudioClip.time = startTimestamp;
        activeAudioClip.Play();
    }

    public void Play(int index, float startVolume = 0.0f, float endVolume = 1.0f, float fadeDuration = DEFAULT_FADE_DURATION, float startTimestamp = 0.0f) {
        if (index < 0 || index >= audioClips.Length) {
            Toolbox.Log("Play(int index): invalid index");
            return;
        }

        StopInstant();
        activeAudioClip = audioClips[index];
        StartCoroutine(PlayAsync(activeAudioClip, startVolume, endVolume, fadeDuration, startTimestamp));
    }

    public void SetVolume(int index, float volume) {
        if (index < 0 || index >= audioClips.Length) {
            Toolbox.Log("SetVolume(int index, float volume): invalid index");
            return;
        }

        audioClips[index].volume = volume;
    }

    private IEnumerator PlayAsync(AudioSource audioSource, float startVolume, float endVolume, float fadeDuration = DEFAULT_FADE_DURATION, float startTimestamp = 0.0f) {
        float volumeDifference = endVolume - startVolume;
        audioSource.volume = startVolume;
        audioSource.Play();
        audioSource.time = startTimestamp;
        while (audioSource.volume < endVolume) {
            audioSource.volume += volumeDifference * Time.deltaTime / fadeDuration;
            yield return null;
        }
        audioSource.volume = endVolume;
    }

    public void StopInstant() {
        if (activeAudioClip == null) {
            Toolbox.Log("Stop(): activeAudioClip is null");
            return;
        }
        activeAudioClip.Stop();
    }

    public void Stop(float fadeDuration = DEFAULT_FADE_DURATION) {
        if (activeAudioClip == null) {
            Toolbox.Log("Stop(): activeAudioClip is null");
            return;
        }

        StopAllCoroutines();
        StartCoroutine(StopAsync(activeAudioClip, fadeDuration));
    }

    private IEnumerator StopAsync(AudioSource audioSource, float fadeDuration = DEFAULT_FADE_DURATION) {
        float volumeDifference = audioSource.volume;
        while (audioSource.volume > 0.001f) {
            audioSource.volume -= volumeDifference * Time.deltaTime / fadeDuration;
            yield return null;
        }
        audioSource.volume = 0.0f;
        audioSource.Stop();

        activeAudioClip = null;
    }
}
