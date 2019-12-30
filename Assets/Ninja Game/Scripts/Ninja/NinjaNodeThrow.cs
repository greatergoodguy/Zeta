using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeThrow : MonoBehaviour, NinjaNode_Base {
    public static NinjaNodeThrow I;

    Ninja ninja;

    float elapsedTime;

    public float shurikenHitSFXDelay = 0.25f;

    void Awake() {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        ninja.SetAnimation(14);
        elapsedTime = 0;
        ActorSFXManager.I.Play(0);
        Invoke("ShurikenHitSFX", shurikenHitSFXDelay);
    }

    void ShurikenHitSFX() {
        ActorSFXManager.I.Play(1);
    }

    public void UpdateNode() {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > 0.3f) {
            ninja.SwitchNode(NinjaNodeIdle.I);
        }
    }

    public void FixedUpdateNode() {}

    public void ExitNode() {}

}
