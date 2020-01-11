using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeCrouch: NinjaNode_Base {
    public static NinjaNodeCrouch I;

    Ninja ninja;

    void Awake()
    {
        I = this;
    }

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(4);
    }

    public override void UpdateNode() {
        ninja.CrouchThrowIfInput();

        if (!Input.GetKey(KeyCode.S)) {
            ninja.SwitchNode(NinjaNodeIdle.I);
        }
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {}

}
