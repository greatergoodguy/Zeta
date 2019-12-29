using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeJumpRise : MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeJumpRise I;

    Ninja ninja;

    bool isActive;

    void Awake() {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(17);
        ninja.GetComponent<Rigidbody2D>().AddForce(this.gameObject.transform.up * Ninja.I.jumpForce);
        isActive = true;
    }

    public void UpdateNode() {
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * Time.deltaTime * Ninja.I.speed;
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * Time.deltaTime * Ninja.I.speed;
        }
        if(ninja.GetVelocity().y < 0) {
            ninja.SwitchNode(NinjaNodeJumpFall.I);
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
