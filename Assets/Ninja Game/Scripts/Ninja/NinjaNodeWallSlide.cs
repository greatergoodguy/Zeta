using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeWallSlide : NinjaNode_Base {

    public float holdThreshold = 0.25f;

    public ParticleSystem wallSlideParticleSystem;

    Ninja ninja;

    ContactPoint2D[] contactPoint2Ds = new ContactPoint2D[16];

    public float gravityScaleEnter = 20f;
    private float gravityScaleExit;
    private Rigidbody2D _rigidbody;

    private float holdThresholdElapsedTime;
    private bool isFacingLeft;

    void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void EnterNode() {
        ninja = GetComponent<Ninja>();
        ninja.SetAnimation(17);

        gravityScaleExit = _rigidbody.gravityScale;
        _rigidbody.gravityScale = gravityScaleEnter;

        wallSlideParticleSystem.Play();
        ActorSFXManager.I.Play(ActorSFXManager.WallHitJump);
        ActorSFXManager.I.Play(ActorSFXManager.WallSlide);

        holdThresholdElapsedTime = 0;
        isFacingLeft = ninja.isFacingLeft();
        if (isFacingLeft) {
            ninja.SetIgnoreRightInput(true);
        }
        else {
            ninja.SetIgnoreLeftInput(true);
        }
    }

    public override void UpdateNode() {
        ninja.WallJumpIfInput();

        if (isFacingLeft) {
            if (ninja.gameInput.KeyDownForRight()) {
                ninja.SetIgnoreRightInput(true);
                holdThresholdElapsedTime = 0;
            }
            if (ninja.gameInput.KeyForRight()) {
                holdThresholdElapsedTime += Time.deltaTime;
            }
            if (ninja.gameInput.KeyUpForRight()) {
                holdThresholdElapsedTime = 0;
            }

            if (holdThresholdElapsedTime > holdThreshold) {
                ninja.SetIgnoreRightInput(false);
            }
            else {
                ninja.SetIgnoreRightInput(true);
            }
            Toolbox.Log("holdThresholdElapsedTime: " + holdThresholdElapsedTime);
        }
        else {
            if (ninja.gameInput.KeyDownForLeft()) {
                ninja.SetIgnoreLeftInput(true);
                holdThresholdElapsedTime = 0;
            }
            if (ninja.gameInput.KeyForLeft()) {
                holdThresholdElapsedTime += Time.deltaTime;
            }
            if (ninja.gameInput.KeyUpForLeft()) {
                holdThresholdElapsedTime = 0;
            }

            if (holdThresholdElapsedTime > holdThreshold) {
                ninja.SetIgnoreLeftInput(false);
            }
            else {
                ninja.SetIgnoreLeftInput(true);
            }
        }
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {
        _rigidbody.gravityScale = gravityScaleExit;

        wallSlideParticleSystem.Stop();
        ActorSFXManager.I.Stop(ActorSFXManager.WallSlide);

        if (isFacingLeft) {
            ninja.SetIgnoreRightInput(false);
        }
        else {
            ninja.SetIgnoreLeftInput(false);
        }
    }

    void OnCollisionStay2D(Collision2D collidingObject) {
        if (IsActive) {
            // Toolbox.Log("OnCollisionStay2D()");
            int numContacts = collidingObject.GetContacts(contactPoint2Ds);
            for (int i = 0; i < numContacts; i++) {
                var contactPoint2D = contactPoint2Ds[i];
                // Toolbox.Log("contactPoint2D.normal - " + contactPoint2D.normal);
                // Debug.DrawRay(contactPoint2D.point, contactPoint2D.normal * 10, Color.red, 2.0f);

                if (contactPoint2D.normal.y > 0.75f && _rigidbody.velocity.y < 20) {
                    ninja.SwitchNode(ninja.nodeIdle);
                    return;
                }
                if (Mathf.Abs(contactPoint2D.normal.x) < 0.75f) {
                    ninja.SwitchNode(ninja.nodeFall);
                    return;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collidingObject) {
        if (IsActive) {
            int numContacts = collidingObject.GetContacts(contactPoint2Ds);
            if(numContacts == 0) {
                ninja.SwitchNode(ninja.nodeFall);
            }
        }
    }
}
