﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeWallJump : NinjaNode_Base {
    public static NinjaNodeWallJump I;

    public float holdDuration = 0.25f;

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    ContactPoint2D[] contactPoint2Ds = new ContactPoint2D[16];

    float elapsedTime;

    void Awake() {
        I = this;
    }

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(9);
        _rigidbody = ninja.GetComponent<Rigidbody2D>();
        if (ninja.isFacingLeft()) {
            ninja.FaceRight();
            Vector2 jumpForce = new Vector2(1, 1).normalized * Ninja.I.jumpForce;
            _rigidbody.AddForce(jumpForce);
        }
        else {
            ninja.FaceLeft();
            Vector2 jumpForce = new Vector2(-1, 1).normalized * Ninja.I.jumpForce;
            _rigidbody.AddForce(jumpForce);
        }

        elapsedTime = 0;
        ninja.SetIgnoreLeftRightInput(true);
        ActorSFXManager.I.Play(ActorSFXManager.Jump);
    }

    public override void UpdateNode() {
        elapsedTime += Time.deltaTime;

        ninja.JumpThrowIfInput();
        ninja.GlideIfInput();

        if (elapsedTime > holdDuration) {
            ninja.SetIgnoreLeftRightInput(false);
        }
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {
        ninja.SetIgnoreLeftRightInput(false);
    }

    void OnCollisionStay2D(Collision2D collidingObject) {
        if (IsActive) {
            Toolbox.Log("OnCollisionStay2D()");
            int numContacts = collidingObject.GetContacts(contactPoint2Ds);
            for(int i=0; i< numContacts; i++) {
                ContactPoint2D contactPoint2D = contactPoint2Ds[i];
                Toolbox.Log("contactPoint2D.normal - " + contactPoint2D.normal);
                Debug.DrawRay(contactPoint2D.point, contactPoint2D.normal * 10, Color.red, 2.0f);

                if (Mathf.Abs(contactPoint2D.normal.x) > 0.75f && _rigidbody.velocity.y < 0) {
                    ninja.SwitchNode(NinjaNodeWallSlide.I);
                    return;
                }
                if (contactPoint2D.normal.y > 0.75f && _rigidbody.velocity.y < 20) {
                    ninja.SwitchNode(NinjaNodeIdle.I);
                    return;
                }
            }
        }
    }
}
