using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetiTitle : SeTi_Base {

    public static SetiTitle I;

    ActorTitleScreen titleScreen;
    ActorWidgets widgets;

    void Awake() {
        I = this;
    }

    // ==================
    // Overridden 
    // ==================
    public override void Enter() {
        titleScreen = ActorTitleScreen.I;
        widgets = ActorWidgets.I;

        titleScreen.ShowPanel();
        titleScreen.EnableUI();
        Ninja.I.DisableControls();
    }

    public override void Exit() {
        titleScreen.HidePanel();
    }

    public void StartGame() {
        widgets.FadeOut(() => {
            SwitchSeason(SetiCutsceneIntro.I);
        });
    }
}