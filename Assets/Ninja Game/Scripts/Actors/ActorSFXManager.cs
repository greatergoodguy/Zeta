using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActorSFXManager : MonoBehaviour {

    /*
	 * 0 - Shuriken Throw
	 * 1 - Shuriken Hit
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
	 * 13 - 
	 * 14 - 
	 * 15 - 
	 * 16 - 
	 * 17 - 
	 * 18 - 
	 * 19 - 
	 * 20 - 
	 * 21 - 
	 * 22 - 
	 * 23 - 
	 * 24 - 
	 * 25 - 
	 * 26 - 
	 * 27 - 
	 * 28 - 
	 * 29 - 
	 * 30 - 
	 * 31 - 
	 * 32 - 
	 * 
	 * 
	 * */

    public static ActorSFXManager I;

    AudioSource[] audioClips;

    void Awake() {
        I = this;
        audioClips = GetComponents<AudioSource>();
    }

    public void Play(int index) {
        if (index < 0 || index >= audioClips.Length) {
            Toolbox.Log("Play(int index): invalid index");
            return;
        }
        audioClips[index].Play();
    }

    public void Stop(int index) {
        if (index < 0 || index >= audioClips.Length) {
            Toolbox.Log("Stop(int index): invalid index");
            return;
        }

        audioClips[index].Stop();
    }
}