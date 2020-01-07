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
        AddEvent(kunoichi.FaceLeft);
        AddEvent(new EventPause(0.5f));
        AddEvent(kunoichi.Throw);
        AddEvent(new EventPause(1.0f));
        AddEvent(kunoichi.FaceRight);
        AddEvent(new EventPause(0.5f));
        AddEvent(kunoichi.Throw);
        AddEvent(new EventPause(1.0f));
        AddEvent(new EventSpeech(kunoichi.gameObject, "I'm on a roll today!"));
        AddEvent(new EventSpeech(kunoichi.gameObject, "Almost time to leave. I'll get 3 more in a row before I go.", EventSpeech.DURATION_LONG));
        AddEvent(SwitchSeasonStage1);
    }

    public override void UpdateSeason() {
    }

    public override void Exit() {
       
    }

    void SwitchSeasonStage1() {
        SwitchSeason(SetiStage1.I);
    }
}