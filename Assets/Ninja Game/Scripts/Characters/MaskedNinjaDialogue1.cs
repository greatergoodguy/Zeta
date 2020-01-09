using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MaskedNinjaDialogue1 : MonoBehaviour {

    bool isTriggered;
    bool shouldPlayCutscene = true;

    void Update() {
        if (isTriggered && Input.GetKeyDown(KeyCode.RightShift) && shouldPlayCutscene) {
            PlayCutscene();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            isTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            isTriggered = false;
        }
    }

    private void PlayCutscene() {
        shouldPlayCutscene = false;
        AddEvent(Ninja.I.DisableGameInput);
        AddEvent(new EventSpeech(gameObject, "Hello World"));
        AddEvent(new EventSpeech(gameObject, "Goodbye World"));
        AddEvent(Ninja.I.EnableGameInputForUser);
    }

    void AddEvent(Event_Base _event) {
        ActorEventDispatcher.I.AddEvent(_event);
    }

    void AddEvent(Action action) {
        ActorEventDispatcher.I.AddEvent(new EventAction(action));
    }
}