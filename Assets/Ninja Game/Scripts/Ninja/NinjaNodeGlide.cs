using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeGlide: NinjaNode_Base {
    public static NinjaNodeGlide I;

    Ninja ninja;

    public float gravityScaleEnter = 20f;
    private float gravityScaleExit;
    private Rigidbody2D _rigidbody;

    bool isActive;

    ContactPoint2D[] contactPoint2Ds = new ContactPoint2D[16];

    void Awake() {
        I = this;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(7);
        
        gravityScaleExit = _rigidbody.gravityScale;
        _rigidbody.gravityScale = gravityScaleEnter;

        isActive = true;
        ActorSFXManager.I.Play(ActorSFXManager.WallHitJump);

    }

    public override void UpdateNode() {
        ninja.JumpThrowIfInput();
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {
        _rigidbody.gravityScale = gravityScaleExit;
        isActive = false;
    }

    void OnCollisionStay2D(Collision2D collidingObject) {
        if (isActive) {
            Toolbox.Log("OnCollisionStay2D()");
            int numContacts = collidingObject.GetContacts(contactPoint2Ds);
            for (int i = 0; i < numContacts; i++) {
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
