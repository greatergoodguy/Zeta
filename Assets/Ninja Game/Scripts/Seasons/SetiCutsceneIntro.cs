using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetiCutsceneIntro : SeTi_Base {

    public static SetiCutsceneIntro I;

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
        //ActorMusicManager.I.PlayInstant(0);
        Time.timeScale = 1;

        widgets = ActorWidgets.I;

        kunoichi = Ninja.I;
        maskedNinja = MaskedNinja.I;

        //AddEvent(
        AddEvent(EventFadeIn.I);
        AddEvent(new EventSpeech(kunoichi.gameObject, "Hello World"));
        AddEvent(new EventSpeech(kunoichi.gameObject, "Goodbye World"));
        AddEvent(new EventSpeech(maskedNinja.gameObject, "Hello World"));
        AddEvent(new EventSpeech(maskedNinja.gameObject, "Goodbye World"));
        AddEvent(new EventSetNinjaAnimation(maskedNinja.gameObject, Constants.NINJA_ANIMATION_RUN));
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

    void AddEvent(Action action) {
        ActorEventDispatcher.I.AddEvent(new EventAction(action));
    }
}