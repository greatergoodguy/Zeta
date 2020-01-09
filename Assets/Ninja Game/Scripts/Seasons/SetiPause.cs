using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetiPause : SeTi_Base {

    public static SetiPause I;

    ActorPauseScreen actorPauseScreen;

    void Awake() {
        I = this;
    }

    // ==================
    // Overridden 
    // ==================
    public override void Enter() {
        actorPauseScreen = ActorPauseScreen.I;

        actorPauseScreen.ShowPanel();
        Ninja.I.DisableGameInput();
        Time.timeScale = 0;
    }

    public override void Exit() {
        actorPauseScreen.HidePanel();
    }

    public void ResumeGame() {
        SwitchSeason(SetiStage1.I);
    }

    public void QuitGame() {
        SwitchSeason(SetiTitle.I);
    }
}