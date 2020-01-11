using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeCrouchThrow : NinjaNode_Base {
    public static NinjaNodeCrouchThrow I;

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    bool isActive;

    float elapsedTime;

    void Awake() {
        I = this;
    }

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(16);
        elapsedTime = 0;
        isActive = true;

        ninja.ThrowShuriken();
    }

    public override void UpdateNode() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.15f) {
            ninja.SwitchNode(NinjaNodeCrouch.I);
        }

        if (!Input.GetKey(KeyCode.S)) {
            ninja.SwitchNode(NinjaNodeIdle.I);
        }
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {
        isActive = false;
    }
}
