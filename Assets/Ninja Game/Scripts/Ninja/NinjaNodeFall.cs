using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeFall: NinjaNode_Base {

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    bool isActive;

    ContactPoint2D[] contactPoint2Ds = new ContactPoint2D[16];

    public override void EnterNode() {
        ninja = GetComponent<Ninja>();
        ninja.SetAnimation(9);
        _rigidbody = ninja.GetComponent<Rigidbody2D>();
        isActive = true;
    }

    public override void UpdateNode() {
        ninja.JumpThrowIfInput();
        ninja.GlideIfInput();
    }


    public override void FixedUpdateNode() {}

    public override void ExitNode() {
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
