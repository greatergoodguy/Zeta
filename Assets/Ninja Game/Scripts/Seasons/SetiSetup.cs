using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetiSetup : SeTi_Base {

    public static SetiSetup I;

    void Awake() {
        I = this;
    }

    public override void Enter() {
        SwitchSeason(SetiTitle.I);
    }
}
