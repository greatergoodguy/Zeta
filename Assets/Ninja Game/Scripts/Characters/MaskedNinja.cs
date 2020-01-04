using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskedNinja : MonoBehaviour {

    public static MaskedNinja I;

    void Awake() {
        I = this;
    }
}
