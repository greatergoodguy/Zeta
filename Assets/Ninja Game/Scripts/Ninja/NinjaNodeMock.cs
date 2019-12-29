using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeMock : MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeMock I;

    void Awake() {
        I = this;
    }

    public void EnterNode() {}

    public void UpdateNode() {}

    public void ExitNode() {}
}
