using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActorSFXManager : MonoBehaviour {

	public const int ShurikenThrow = 0;
	public const int ShurikenHit = 1;
	public const int WallHitJump = 2;
	public const int WallSlide = 3;
	public const int Glide = 4;
	public const int Jump = 5;

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
