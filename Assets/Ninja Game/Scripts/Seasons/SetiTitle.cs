using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetiTitle : SeTi_Base {

    public static SetiTitle I;

    ActorTitleScreen titleScreen;
    ActorWidgets widgets;
    ActorMusicManager musicManager;

    void Awake() {
        I = this;
    }

    // ==================
    // Overridden 
    // ==================
    public override void Enter() {
        titleScreen = ActorTitleScreen.I;
        widgets = ActorWidgets.I;
        musicManager = ActorMusicManager.I;

        titleScreen.ShowPanel();
        titleScreen.EnableUI();
        musicManager.Play(1);
        Ninja.I.DisableControls();
        Time.timeScale = 1;
    }

    public override void Exit() {
        titleScreen.HidePanel();
    }

    public void StartGame() {
        musicManager.Stop();
        widgets.FadeOut(() => {
            SwitchSeason(SetiCutsceneIntro.I);
        });
    }
}