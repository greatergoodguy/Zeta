using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeJumpFall : MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeJumpFall I;

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    bool isActive;

    void Awake() {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(18);
        _rigidbody = ninja.GetComponent<Rigidbody2D>();
        isActive = true;
    }

    public void UpdateNode() {}

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
