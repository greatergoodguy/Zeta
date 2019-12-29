using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeJumpFall : MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeJumpFall I;

    Ninja ninja;

    bool isActive;

    void Awake() {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(18);
        isActive = true;
    }

    public void UpdateNode() {
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * Time.deltaTime * Ninja.I.speed;

        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * Time.deltaTime * Ninja.I.speed;
        }
    }

    public void ExitNode() {
        isActive = false;
    }

    void OnCollisionEnter2D(Collision2D collidingObject) {
        if (isActive) {
            ninja.SwitchNode(NinjaNodeIdle.I);
        }
    }
}
