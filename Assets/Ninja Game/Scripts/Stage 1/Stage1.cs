using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour {

    public static Stage1 I;

    GameInputForCutscene gameInputForCutscene;
    ActorWidgets widgets;
    Ninja kunoichi;

    bool isActive;
    int targetHitCounter;

    GameObject goEnvironment1;
    GameObject goTarget1;
    GameObject goTarget2;
    GameObject goSkipTarget;
    GameObject goEnvironment1SpawnPoint;
    GameObject goEnvironment1Transition;


    GameObject goEnvironment2;
    GameObject goEnvironment2SpawnPoint;
    GameObject goEnvironment2Transition;

    void Awake() {
        I = this;

        goEnvironment1 = transform.Find("Environment 1").gameObject;
        goTarget1 = transform.Find("Environment 1/Targets/Target (1)").gameObject;
        goTarget2 = transform.Find("Environment 1/Targets/Target (2)").gameObject;
        goSkipTarget = transform.Find("Environment 1/Targets/Skip Target").gameObject;
        goEnvironment1SpawnPoint = transform.Find("Environment 1/Spawn Point").gameObject;
        goEnvironment1Transition = transform.Find("Environment 1/Transition to Temple").gameObject;

        goEnvironment2 = transform.Find("Environment 2").gameObject;
        goEnvironment2SpawnPoint = transform.Find("Environment 2/Spawn Point").gameObject;
        goEnvironment2Transition = transform.Find("Environment 2/Transition to Kyte's House").gameObject;
    }

    private void Update() {}

    public void EnableStage() {
        gameInputForCutscene = GameInputForCutscene.I;
        widgets = ActorWidgets.I;
        kunoichi = Ninja.GetPlayer();
        isActive = true;
        targetHitCounter = 0;

        DestroyTriggersPart1();

        goTarget1.AddComponent<Stage1Target>();
        goTarget2.AddComponent<Stage1Target>();
        goSkipTarget.AddComponent<Stage1SkipTarget>();

        goEnvironment1.SetActive(true);
        goEnvironment2.SetActive(false);
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
            this.AddEvent(new EventSpeech(kunoichi.gameObject, "And the savior of the world is.... KYTE!!!!"));
            this.AddEvent(new EventSpeech(kunoichi.gameObject, "Alright, school's bout to start. Time to bounce."));
        }
    }

    public void OnSkipTarget() {
        if (!isActive) {
            return;
        }

        DestroyTriggersPart1();
        this.AddEvent(new EventSpeech(kunoichi.gameObject, "I don't need anymore practice."));
        this.AddEvent(new EventSpeech(kunoichi.gameObject, "Besides... this is the perfect \"running to school\" weather."));
    }

    public void OnTransitionToTemple() {
        if (!isActive) {
            return;
        }

        this.AddEvent(() => {
            kunoichi.SetGameInput(gameInputForCutscene);
            gameInputForCutscene._KeyForRight = true;
        });
        this.AddEvent(EventFadeOut.I);
        this.AddEvent(() => {
            goEnvironment1.SetActive(false);
            goEnvironment2.SetActive(true);
            goEnvironment2Transition.SetActive(false);
            kunoichi.transform.position = goEnvironment2SpawnPoint.transform.position;
        });
        this.AddEvent(EventFadeIn.I);
        this.AddEvent(() => {
            gameInputForCutscene._KeyForRight = false;
            kunoichi.EnableGameInputForUser();
            goEnvironment2Transition.SetActive(true);
        });
    }

    public void OnTransitionToKytesHouse() {
        if (!isActive) {
            return;
        }

        this.AddEvent(() => {
            kunoichi.SetGameInput(gameInputForCutscene);
            gameInputForCutscene._KeyForLeft = true;
        });
        this.AddEvent(EventFadeOut.I);
        this.AddEvent(() => {
            goEnvironment1.SetActive(true);
            goEnvironment2.SetActive(false);
            goEnvironment1Transition.SetActive(false);
            kunoichi.transform.position = goEnvironment1SpawnPoint.transform.position;
        });
        this.AddEvent(EventFadeIn.I);
        this.AddEvent(() => {
            gameInputForCutscene._KeyForLeft = false;
            kunoichi.EnableGameInputForUser();
            goEnvironment1Transition.SetActive(true);
        });
    }

    void DestroyTriggersPart1() {
        Destroy(goTarget1.GetComponent<Stage1Target>());
        Destroy(goTarget2.GetComponent<Stage1Target>());
        Destroy(goSkipTarget.GetComponent<Stage1SkipTarget>());
    }
}
