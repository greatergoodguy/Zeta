using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeJump : NinjaNode_Base {

    Ninja ninja;

    private bool weDidOurJob = false;

    public override void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(9);
        var _rigidbody = ninja.GetComponent<Rigidbody2D>();
        Vector2 jumpForce = this.gameObject.transform.up * Ninja.I.jumpForce;
        _rigidbody.AddForce(jumpForce);
        ActorSFXManager.I.Play(ActorSFXManager.Jump);
    }

    public override void UpdateNode() {
        if (weDidOurJob) {
            ninja.SwitchNode(ninja.nodeFall);
        } else {
            weDidOurJob = true;
        }
    }

    public override void FixedUpdateNode() {}

    public override void ExitNode() {}
}
