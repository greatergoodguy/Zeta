using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeCrouch: MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeCrouch I;

    Ninja ninja;

    void Awake()
    {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(4);
    }

    public void UpdateNode() {
        if (!Input.GetKey(KeyCode.S)) {
            ninja.SwitchNode(NinjaNodeIdle.I);
        }
    }

    public void FixedUpdateNode() {}

    public void ExitNode() {}

}
