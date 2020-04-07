using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetiTitle : SeTi_Base {

    public static SetiTitle I;

    Ninja player;

    ActorTitleScreen titleScreen;
    ActorWidgets widgets;
    ActorMusicManager musicManager;

    bool isGameStarting = false;

    void Awake() {
        I = this;
    }

    // ==================
    // Overridden 
    // ==================
    public override void Enter() {
        player = Ninja.GetPlayer();
        titleScreen = ActorTitleScreen.I;
        widgets = ActorWidgets.I;
        musicManager = ActorMusicManager.I;

        titleScreen.ShowPanel();
        titleScreen.EnableUI();
        musicManager.Play(1);
        player.DisableGameInput();
        Time.timeScale = 1;
    }

    public override void Exit() {
        titleScreen.HidePanel();
    }

    public void StartGame() {
        if(isGameStarting) {
            return;
        }

        isGameStarting = true;
        musicManager.Stop();
        widgets.FadeOut(() => {
            SwitchSeason(SetiCutsceneIntro.I);
            isGameStarting = false;
        });
    }

    public void QuitGame() {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}