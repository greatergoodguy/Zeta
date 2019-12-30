using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeJumpThrow : MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeJumpThrow I;

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    bool isActive;

    float elapsedTime;

    void Awake() {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(11);
        elapsedTime = 0;
        isActive = true;

        ninja.ThrowShuriken();
    }

    public void UpdateNode() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.15f) {
            ninja.SwitchNode(NinjaNodeFall.I);
        }
    }


    public void FixedUpdateNode() {}

    public void ExitNode() {
        isActive = false;
    }

    void OnCollisionEnter2D(Collision2D collidingObject) {
        if (isActive) {
            ninja.SwitchNode(NinjaNodeIdle.I);
        }
    }

}
