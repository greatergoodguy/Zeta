using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NinjaNode_Base : MonoBehaviour {

    public bool IsActive { get; set; }

    public abstract void EnterNode();
    public abstract void UpdateNode();
    public abstract void FixedUpdateNode();
    public abstract void ExitNode();
}
