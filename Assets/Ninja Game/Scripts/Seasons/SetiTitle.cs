using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetiTitle : SeTi_Base {

    public static SetiTitle I;

    ActorTitleScreen titleScreen;

    void Awake() {
        I = this;
    }

    // ==================
    // Overridden 
    // ==================
    public override void Enter() {
        titleScreen = ActorTitleScreen.I;

        titleScreen.ShowPanel();
        Ninja.I.DisableControls();
        Time.timeScale = 0;
    }

    public override void Exit() {
        titleScreen.HidePanel();
    }

    public void StartGame() {
        SwitchSeason(SetiGame.I);
    }
}