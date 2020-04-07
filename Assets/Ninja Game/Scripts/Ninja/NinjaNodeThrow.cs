using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeThrow : NinjaNode_Base {
    
    Ninja ninja;

    float elapsedTime;

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(14);
        elapsedTime = 0;

        ninja.ThrowShuriken();
    }

    public override void UpdateNode() {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > 0.15f) {
            ninja.SwitchNode(ninja.nodeIdle);
        }
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {}
}