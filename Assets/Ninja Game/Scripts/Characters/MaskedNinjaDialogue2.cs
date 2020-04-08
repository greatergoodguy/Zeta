using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MaskedNinjaDialogue2 : MonoBehaviour {

    private Ninja player;

    bool isTriggered;
    bool shouldPlayCutscene = true;

    Material material;

    private void Awake() {
        material = GetComponent<Renderer>().material;
    }

    void Start() {
        player = Ninja.GetPlayer();
        HideOutline();
    }

    void Update() {
        if (isTriggered && Input.GetKeyDown(KeyCode.RightShift) && shouldPlayCutscene) {
            PlayCutscene();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            isTriggered = true;
            ShowOutline();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            isTriggered = false;
            HideOutline();
        }
    }

    private void ShowOutline() { 
        material.SetFloat("_OutlineAlpha", 1f);
    }

    private void HideOutline() {
        material.SetFloat("_OutlineAlpha", 0f);
    }

    private void PlayCutscene() {
        shouldPlayCutscene = false;
        AddEvent(HideOutline);
        AddEvent(() => { shouldPlayCutscene = true; });

    }

    void AddEvent(Event_Base _event) {
        ActorEventDispatcher.I.AddEvent(_event);
    }

    void AddEvent(Action action) {
        ActorEventDispatcher.I.AddEvent(new EventAction(action));
    }
}