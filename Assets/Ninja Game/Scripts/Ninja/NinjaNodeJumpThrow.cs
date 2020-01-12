using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeJumpThrow : NinjaNode_Base {
    public static NinjaNodeJumpThrow I;

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    bool isActive;

    float elapsedTime;

    void Awake() {
        I = this;
    }

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(11);
        elapsedTime = 0;
        isActive = true;

        ninja.ThrowShuriken();
    }

    public override void UpdateNode() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.15f) {
            ninja.SwitchNode(NinjaNodeFall.I);
        } else {
            ninja.GlideIfInput();
        }
    }


    public override void FixedUpdateNode() {}

    public override void ExitNode() {
        isActive = false;
    }

    void OnCollisionEnter2D(Collision2D collidingObject) {
        if (isActive) {
            ninja.SwitchNode(NinjaNodeIdle.I);
        }
    }

}
