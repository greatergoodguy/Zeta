using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeFall: MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeFall I;

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    bool isActive;

    void Awake() {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(9);
        isActive = true;
    }

    public void UpdateNode() {
        ninja.JumpThrowIfInput();
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
