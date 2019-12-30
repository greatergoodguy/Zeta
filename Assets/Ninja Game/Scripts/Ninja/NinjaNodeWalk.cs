using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeWalk : MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeWalk I;

    Ninja ninja;

    private Rigidbody2D _rigidbody;

    void Awake() {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        //ninja.SetAnimation(15);
        ninja.SetAnimation(12);
        _rigidbody = ninja.GetComponent<Rigidbody2D>();
    }

    public void UpdateNode() {
        ninja.JumpIfInput();
        ninja.ThrowIfInput();
        ninja.CrouchIfInput();

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
            ninja.SwitchNode(NinjaNodeIdle.I);
        }
    }

    public void FixedUpdateNode() {}

    public void ExitNode() {}

    public NinjaNode_Base GetNextNode() {
        return NinjaNodeMock.I;
    }

    public bool IsNodeFinished() {
        return false;
    }
}
