using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeIdle : NinjaNode_Base {
    public static NinjaNodeIdle I;

    Ninja ninja;

    void Awake() {
        I = this;
    }

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(0);
    }

    public override void UpdateNode() {
        ninja.JumpIfInput();
        ninja.ThrowIfInput();
        ninja.CrouchIfInput();
        ninja.WalkIfInput();
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {}

}
