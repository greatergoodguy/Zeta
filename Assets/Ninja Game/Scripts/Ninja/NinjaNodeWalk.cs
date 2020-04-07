using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeWalk : NinjaNode_Base {

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void EnterNode() {
        ninja = GetComponent<Ninja>();
        ninja.SetAnimation(12);
    }

    public override void UpdateNode() {
        ninja.JumpIfInput();
        ninja.ThrowIfInput();
        ninja.CrouchIfInput();
        ninja.IdleIfInput();
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {}

    public NinjaNode_Base GetNextNode() {
        return ninja.nodeMock;
    }

    public bool IsNodeFinished() {
        return false;
    }

    void OnCollisionExit2D(Collision2D collidingObject) {
        if (IsActive) {
        }
    }
}
