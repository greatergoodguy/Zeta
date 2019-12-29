using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeIdle : MonoBehaviour, NinjaNode_Base
{
    public static NinjaNodeIdle I;

    public Ninja ninja;

    void Awake()
    {
        I = this;
    }

    public void EnterNode() {
        ninja = Ninja.I;
        //ninja.GetComponent<Animator>().SetInteger("animation", 1);
    }

    public void UpdateNode() {
    }

    public void ExitNode() {
    }

    public NinjaNode_Base GetNextNode() {
        return NinjaNodeMock.I;
    }

    public bool IsNodeFinished()
    {
        return false;
    }

}
