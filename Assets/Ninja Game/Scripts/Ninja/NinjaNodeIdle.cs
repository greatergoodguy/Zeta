using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeIdle : MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeIdle I;

    Ninja ninja;

    void Awake()
    {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(0);
    }

    public void UpdateNode() {
        ninja.JumpIfInput();
        ninja.ThrowIfInput();
        ninja.CrouchIfInput();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            ninja.SwitchNode(NinjaNodeWalk.I);
        }

    }

    public void FixedUpdateNode() {}

    public void ExitNode() {}

}
