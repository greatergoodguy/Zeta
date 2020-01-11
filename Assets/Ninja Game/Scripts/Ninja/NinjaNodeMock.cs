using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeMock : NinjaNode_Base {
    public static NinjaNodeMock I;

    void Awake() {
        I = this;
    }

    public override void EnterNode() {}

    public override void UpdateNode() {}

    public override void FixedUpdateNode() {}

    public override void ExitNode() {}
}
