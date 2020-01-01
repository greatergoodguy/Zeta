using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeCrouchThrow : MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeCrouchThrow I;

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    bool isActive;

    float elapsedTime;

    void Awake() {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(16);
        elapsedTime = 0;
        isActive = true;

        ninja.ThrowShuriken();
    }

    public void UpdateNode() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.15f) {
            ninja.SwitchNode(NinjaNodeCrouch.I);
        }

        if (!Input.GetKey(KeyCode.S)) {
            ninja.SwitchNode(NinjaNodeIdle.I);
        }
    }


    public void FixedUpdateNode() {}

    public void ExitNode() {
        isActive = false;
    }
}
