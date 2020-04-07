using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeCrouchThrow : NinjaNode_Base {

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    bool isActive;

    float elapsedTime;

    public override void EnterNode() {
        ninja = GetComponent<Ninja>();
        ninja.SetAnimation(16);
        elapsedTime = 0;
        isActive = true;

        ninja.ThrowShuriken();
    }

    public override void UpdateNode() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.15f) {
            ninja.SwitchNode(ninja.nodeCrouch);
        }

        if (!Input.GetKey(KeyCode.S)) {
            ninja.SwitchNode(ninja.nodeIdle);
        }
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {
        isActive = false;
    }
}
