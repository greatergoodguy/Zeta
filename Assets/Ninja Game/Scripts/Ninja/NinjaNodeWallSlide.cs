using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeWallSlide : NinjaNode_Base {
    public static NinjaNodeWallSlide I;

    Ninja ninja;

    bool isActive;

    ContactPoint2D[] contactPoint2Ds = new ContactPoint2D[16];

    void Awake() {
        I = this;
    }

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(17);

        isActive = true;

        Collider2D _collider2D = ninja.GetComponent<Collider2D>();
        _collider2D.sharedMaterial.friction = 0f;
    }

    public override void UpdateNode() {}

    public override void FixedUpdateNode() {}

    public override void ExitNode() {
        Collider2D _collider2D = ninja.GetComponent<Collider2D>();
        _collider2D.sharedMaterial.friction = 1;

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

                if (contactPoint2D.normal.y > 0.75f) {
                    ninja.SwitchNode(NinjaNodeIdle.I);
                    return;
                }
                if (contactPoint2D.normal.x < 0.75f) {
                    ninja.SwitchNode(NinjaNodeFall.I);
                    return;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collidingObject) {
        if (isActive) {
            int numContacts = collidingObject.GetContacts(contactPoint2Ds);
            if(numContacts == 0) {
                ninja.SwitchNode(NinjaNodeFall.I);
            }
        }
    }
}
