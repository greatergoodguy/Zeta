using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour {

    public static Stage1 I;

    Ninja kunoichi;

    bool isActive;
    int targetHitCounter;

    GameObject goTarget1;
    GameObject goTarget2;
    GameObject goSkipTarget;

    void Awake() {
        I = this;

        goTarget1 = transform.Find("Targets/Target (1)").gameObject;
        goTarget2 = transform.Find("Targets/Target (2)").gameObject;
        goSkipTarget = transform.Find("Targets/Skip Target").gameObject;
    }

    public void EnableStage() {
        kunoichi = Ninja.I;
        isActive = true;
        targetHitCounter = 0;

        DestroyTriggersPart1();

        goTarget1.AddComponent<Stage1Target>();
        goTarget2.AddComponent<Stage1Target>();
        goSkipTarget.AddComponent<Stage1SkipTarget>();
    }

    public void DisableStage() {
        isActive = false;
    }

    public void OnTargetHit() {
        if(!isActive) {
            return;
        }

        targetHitCounter += 1;

        if (targetHitCounter == 3) {
            DestroyTriggersPart1();
            AddEvent(new EventSpeech(kunoichi.gameObject, "And the savior of the world is.... KYTE!!!!"));
            AddEvent(new EventSpeech(kunoichi.gameObject, "Alright, school's bout to start. Time to bounce."));
        }
    }

    public void OnSkipTarget() {
        if (!isActive) {
            return;
        }

        DestroyTriggersPart1();
        AddEvent(new EventSpeech(kunoichi.gameObject, "I don't need anymore practice."));
        AddEvent(new EventSpeech(kunoichi.gameObject, "Besides... this is the perfect \"running to school\" weather."));
    }

    void DestroyTriggersPart1() {
        Destroy(goTarget1.GetComponent<Stage1Target>());
        Destroy(goTarget2.GetComponent<Stage1Target>());
        Destroy(goSkipTarget.GetComponent<Stage1SkipTarget>());
    }

    // ==================
    // Event Helpers
    // ==================
    protected void AddEvent(Event_Base _event) {
        ActorEventDispatcher.I.AddEvent(_event);
    }

    protected void AddEvent(Action action, float duration = EventAction.DEFAULT_DURATION) {
        ActorEventDispatcher.I.AddEvent(new EventAction(action));
    }
}
