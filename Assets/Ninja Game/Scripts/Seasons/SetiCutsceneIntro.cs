using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetiCutsceneIntro : SeTi_Base {

    public static SetiCutsceneIntro I;

    ActorMusicManager musicManager;
    ActorWidgets widgets;

    Ninja kunoichi;
    MaskedNinja maskedNinja;

    void Awake() {
        I = this;
    }

    // ==================
    // Overridden 
    // ==================
    public override void Enter() {
        Time.timeScale = 1;

        musicManager = ActorMusicManager.I;
        widgets = ActorWidgets.I;

        kunoichi = Ninja.I;
        maskedNinja = MaskedNinja.I;

        musicManager.Play(2);

        kunoichi.DisableControls();
        widgets.FadeIn();
        AddEvent(new EventPause(1.0f));
        AddEvent(kunoichi.Throw);
        AddEvent(new EventPause(1.0f));
        AddEvent(kunoichi.Throw);
        AddEvent(new EventPause(1.0f));
        AddEvent(kunoichi.Throw);
        //AddEvent(new EventSpeech(kunoichi.gameObject, "Hello World"));
        //AddEvent(new EventSpeech(kunoichi.gameObject, "Goodbye World"));
        //AddEvent(new EventSpeech(maskedNinja.gameObject, "Hello World"));
        //AddEvent(new EventSpeech(maskedNinja.gameObject, "Goodbye World"));
        //AddEvent(new EventSetNinjaAnimation(maskedNinja.gameObject, Constants.NINJA_ANIMATION_RUN));
    }

    public override void UpdateSeason() {
    }

    public override void Exit() {
       
    }


    // ==================
    // Event Helpers
    // ==================
    void AddEvent(Event_Base _event) {
        ActorEventDispatcher.I.AddEvent(_event);
    }

    void AddEvent(Action action, float duration = EventAction.DEFAULT_DURATION) {
        ActorEventDispatcher.I.AddEvent(new EventAction(action));
    }
}