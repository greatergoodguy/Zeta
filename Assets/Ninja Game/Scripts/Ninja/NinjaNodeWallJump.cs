using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeWallJump : NinjaNode_Base {

    public float holdDuration = 0.25f;

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    ContactPoint2D[] contactPoint2Ds = new ContactPoint2D[16];

    float elapsedTime;

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(9);
        _rigidbody = ninja.GetComponent<Rigidbody2D>();
        if (ninja.isFacingLeft()) {
            ninja.FaceRight();
            Vector2 jumpForce = new Vector2(1, 1).normalized * Ninja.I.jumpForce;
            _rigidbody.AddForce(jumpForce);
            ninja.SetIgnoreLeftInput(true);
        }
        else {
            ninja.FaceLeft();
            Vector2 jumpForce = new Vector2(-1, 1).normalized * Ninja.I.jumpForce;
            _rigidbody.AddForce(jumpForce);
            ninja.SetIgnoreRightInput(true);
        }

        elapsedTime = 0;
        ActorSFXManager.I.Play(ActorSFXManager.Jump);
    }

    public override void UpdateNode() {
        ninja.JumpThrowIfInput();
        ninja.GlideIfInput();

        if (elapsedTime < holdDuration) {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > holdDuration) {
                ninja.SetIgnoreLeftInput(false);
                ninja.SetIgnoreRightInput(false);
            }
        }
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {
        ninja.SetIgnoreLeftInput(false);
        ninja.SetIgnoreRightInput(false);
    }

    void OnCollisionStay2D(Collision2D collidingObject) {
        if (IsActive) {
            Toolbox.Log("OnCollisionStay2D()");
            int numContacts = collidingObject.GetContacts(contactPoint2Ds);
            for(int i=0; i< numContacts; i++) {
                ContactPoint2D contactPoint2D = contactPoint2Ds[i];
                Toolbox.Log("contactPoint2D.normal - " + contactPoint2D.normal);
                Debug.DrawRay(contactPoint2D.point, contactPoint2D.normal * 10, Color.red, 2.0f);

                if (Mathf.Abs(contactPoint2D.normal.x) > 0.75f && _rigidbody.velocity.y <= 0) {
                    ninja.SwitchNode(ninja.nodeWallSlide);
                    return;
                }
                if (contactPoint2D.normal.y > 0.75f && _rigidbody.velocity.y < 20) {
                    ninja.SwitchNode(ninja.nodeIdle);
                    return;
                }
            }
        }
    }
}
