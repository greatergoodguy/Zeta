using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour {

    NinjaNode_Base ninjaNode;

    void Awake() {
            
    }

    void Start() {
        ninjaNode = NinjaNodeMock.I;
        ninjaNode.EnterNode();
        Toolbox.Log(ninjaNode.GetType().Name + ": Enter");
    }

    void Update() {

        ninjaNode.UpdateNode();
        if (ninjaNode.IsNodeFinished()) {
            ninjaNode.ExitNode();
            Toolbox.Log(ninjaNode.GetType().Name + ": Exit");
            ninjaNode = ninjaNode.GetNextNode();
            ninjaNode.EnterNode();
            Toolbox.Log(ninjaNode.GetType().Name + ": Enter");
        }
    }
}
