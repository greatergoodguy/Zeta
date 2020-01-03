using UnityEngine;
using System.Collections;

public class SetiMock : SeTi_Base {

    public static SetiMock I;

    void Awake() {
        I = this;
    }

}