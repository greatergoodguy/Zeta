using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaNodeMock : MonoBehaviour, NinjaNode_Base
{
    public static NinjaNodeMock I;

    void Awake()
    {
        I = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update() {

    }

    public void EnterNode() {
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
