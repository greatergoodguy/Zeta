using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeIdle : NinjaNode_Base {
    public static NinjaNodeIdle I;

    Ninja ninja;

    ContactPoint2D[] contactPoint2Ds = new ContactPoint2D[16];

    Rigidbody2D rigidbody;

    void Awake() {
        I = this;
    }

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(0);

        rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void UpdateNode() {
        ninja.JumpIfInput();
        ninja.ThrowIfInput();
        ninja.CrouchIfInput();
        ninja.WalkIfInput();
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


    void OnCollisionStay2D(Collision2D collidingObject) {
        if (IsActive) {
            // Toolbox.Log("OnCollisionStay2D()");
            int numContacts = collidingObject.GetContacts(contactPoint2Ds);
            for (int i = 0; i < numContacts; i++) {
                var contactPoint2D = contactPoint2Ds[i];
                if (contactPoint2D.normal.y > 0.2f) {
                    rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collidingObject) {
        if (IsActive) {
        }
    }
}
