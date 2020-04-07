using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetiStage1 : SeTi_Base {

    public static SetiStage1 I;

    Stage1 stage1;
    Ninja kunoichi;

    void Awake() {
        I = this;
    }

    // ==================
    // Overridden 
    // ==================
    public override void Enter() {
        stage1 = Stage1.I;
        kunoichi = Ninja.GetPlayer();

        stage1.EnableStage();
        kunoichi.EnableGameInputForUser();
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