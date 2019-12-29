using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeJumpRise : MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeJumpRise I;

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    bool isActive;

    void Awake() {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(17);
        _rigidbody = ninja.GetComponent<Rigidbody2D>();
        Vector2 jumpForce = this.gameObject.transform.up * Ninja.I.jumpForce;
        _rigidbody.AddForce(jumpForce);
        isActive = true;
    }

    public void UpdateNode() {
        if (ninja.GetVelocity().y < 0) {
            ninja.SwitchNode(NinjaNodeJumpFall.I);
        }
    }


    public void FixedUpdateNode() {
        //ninja.MoveHorizontal();
    }

    public void ExitNode() {
        isActive = false;
    }

    void OnCollisionEnter2D(Collision2D collidingObject) {
        if (isActive) {
            ninja.SwitchNode(NinjaNodeIdle.I);
        }
    }
}
