using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeWallSlide : MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeWallSlide I;

    Ninja ninja;

    bool isActive;

    ContactPoint2D[] contactPoint2Ds = new ContactPoint2D[16];

    void Awake() {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(17);

        isActive = true;
    }

    public void UpdateNode() {
    }


    public void FixedUpdateNode() { }

    public void ExitNode() {
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
