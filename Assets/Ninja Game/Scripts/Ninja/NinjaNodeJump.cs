using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeJump : NinjaNode_Base {
    public static NinjaNodeJump I;

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    ContactPoint2D[] contactPoint2Ds = new ContactPoint2D[16];

    void Awake() {
        I = this;
    }

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(9);
        _rigidbody = ninja.GetComponent<Rigidbody2D>();
        Vector2 jumpForce = this.gameObject.transform.up * Ninja.I.jumpForce;
        _rigidbody.AddForce(jumpForce);
        ActorSFXManager.I.Play(ActorSFXManager.WallHitJump);
    }

    public override void UpdateNode() {
        ninja.JumpThrowIfInput();
        ninja.GlideIfInput();
    }


    public override void FixedUpdateNode() {}

    public override void ExitNode() {}

    void OnCollisionStay2D(Collision2D collidingObject) {
        if (IsActive) {
            Toolbox.Log("OnCollisionStay2D()");
            int numContacts = collidingObject.GetContacts(contactPoint2Ds);
            for(int i=0; i< numContacts; i++) {
                ContactPoint2D contactPoint2D = contactPoint2Ds[i];
                Toolbox.Log("contactPoint2D.normal - " + contactPoint2D.normal);
                Debug.DrawRay(contactPoint2D.point, contactPoint2D.normal * 10, Color.red, 2.0f);

                if (contactPoint2D.normal.x > 0.75f && _rigidbody.velocity.y < 0) {
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
