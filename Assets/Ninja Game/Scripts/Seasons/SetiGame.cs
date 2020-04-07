using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetiGame: SeTi_Base {

    public static SetiGame I;

    Ninja player;

    void Awake() {
        I = this;
    }

    // ==================
    // Overridden 
    // ==================
    public override void Enter() {
        player = Ninja.GetPlayer();
        //ActorMusicManager.I.PlayInstant(0);

        player.EnableGameInputForUser();
        Time.timeScale = 1;
    }

    public override void UpdateSeason() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            SwitchSeason(SetiPause.I);
        }
    }

    public override void Exit() {
       
    }
}