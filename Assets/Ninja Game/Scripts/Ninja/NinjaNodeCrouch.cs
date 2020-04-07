using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeCrouch: NinjaNode_Base {

    Ninja ninja;

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(4);
    }

    public override void UpdateNode() {
        ninja.CrouchThrowIfInput();

        if (!Input.GetKey(KeyCode.S)) {
            ninja.SwitchNode(ninja.nodeIdle);
        }
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {}

}
