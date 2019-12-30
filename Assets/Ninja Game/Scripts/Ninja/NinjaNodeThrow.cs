using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeThrow : MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeThrow I;

    Ninja ninja;

    float elapsedTime;

    void Awake() {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(14);
        elapsedTime = 0;

        ninja.ThrowShuriken();
    }

    public void UpdateNode() {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > 0.15f) {
            ninja.SwitchNode(NinjaNodeIdle.I);
        }
    }

    public void FixedUpdateNode() {}

    public void ExitNode() {}

}
