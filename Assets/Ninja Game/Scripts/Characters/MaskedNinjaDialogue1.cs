using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MaskedNinjaDialogue1 : MonoBehaviour {

    private Ninja player;

    bool isTriggered;
    bool shouldPlayCutscene = true;

    GameObject goVisualNormal;
    GameObject goVisualOutline;

    private void Awake() {
        goVisualNormal = transform.Find("Visual Normal").gameObject;
        goVisualOutline = transform.Find("Visual Outline").gameObject;
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
        goVisualOutline.SetActive(true);
        goVisualNormal.SetActive(false);
    }

    private void HideOutline() {
        goVisualOutline.SetActive(false);
        goVisualNormal.SetActive(true);
    }

    private void PlayCutscene() {
        shouldPlayCutscene = false;
        AddEvent(HideOutline);
        AddEvent(player.DisableGameInput);
        AddEvent(new EventSpeech(gameObject, "Hello World"));
        AddEvent(new EventSpeech(gameObject, "Goodbye World"));
        AddEvent(player.EnableGameInputForUser);
        AddEvent(() => { shouldPlayCutscene = true; });

    }

    void AddEvent(Event_Base _event) {
        ActorEventDispatcher.I.AddEvent(_event);
    }

    void AddEvent(Action action) {
        ActorEventDispatcher.I.AddEvent(new EventAction(action));
    }
}