using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeWalk : MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeWalk I;

    Ninja ninja;

    void Awake() {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(15);
    }

    public void UpdateNode() {
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * Time.deltaTime * Ninja.I.speed;

        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * Time.deltaTime * Ninja.I.speed;
        }

        if (Input.GetKey(KeyCode.Space)) {
            ninja.SwitchNode(NinjaNodeJumpRise.I);
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && ninja != null) {
            ninja.SwitchNode(NinjaNodeIdle.I);
        }
    }

    public void ExitNode() {}

    public NinjaNode_Base GetNextNode() {
        return NinjaNodeMock.I;
    }

    public bool IsNodeFinished() {
        return false;
    }
}
