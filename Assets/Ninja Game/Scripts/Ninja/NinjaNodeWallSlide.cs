using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeWallSlide : NinjaNode_Base {
    public static NinjaNodeWallSlide I;

    public ParticleSystem wallSlideParticleSystem;

    Ninja ninja;

    ContactPoint2D[] contactPoint2Ds = new ContactPoint2D[16];

    public float gravityScaleEnter = 20f;
    private float gravityScaleExit;
    private Rigidbody2D _rigidbody;

    void Awake() {
        I = this;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(17);

        gravityScaleExit = _rigidbody.gravityScale;
        _rigidbody.gravityScale = gravityScaleEnter;

        wallSlideParticleSystem.Play();
        ActorSFXManager.I.Play(ActorSFXManager.WallHitJump);
        ActorSFXManager.I.Play(ActorSFXManager.WallSlide);
    }

    public override void UpdateNode() {
        ninja.WallJumpIfInput();
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {
        _rigidbody.gravityScale = gravityScaleExit;

        wallSlideParticleSystem.Stop();
        ActorSFXManager.I.Stop(ActorSFXManager.WallSlide);
    }

    void OnCollisionStay2D(Collision2D collidingObject) {
        if (IsActive) {
            Toolbox.Log("OnCollisionStay2D()");
            int numContacts = collidingObject.GetContacts(contactPoint2Ds);
            for (int i = 0; i < numContacts; i++) {
                var contactPoint2D = contactPoint2Ds[i];
                Toolbox.Log("contactPoint2D.normal - " + contactPoint2D.normal);
                // Debug.DrawRay(contactPoint2D.point, contactPoint2D.normal * 10, Color.red, 2.0f);

                if (contactPoint2D.normal.y > 0.75f && _rigidbody.velocity.y < 20) {
                    ninja.SwitchNode(NinjaNodeIdle.I);
                    return;
                }
                if (Mathf.Abs(contactPoint2D.normal.x) < 0.75f) {
                    ninja.SwitchNode(NinjaNodeFall.I);
                    return;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collidingObject) {
        if (IsActive) {
            int numContacts = collidingObject.GetContacts(contactPoint2Ds);
            if(numContacts == 0) {
                ninja.SwitchNode(NinjaNodeFall.I);
            }
        }
    }
}
