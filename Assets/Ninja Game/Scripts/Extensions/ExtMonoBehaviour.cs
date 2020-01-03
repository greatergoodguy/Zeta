using UnityEngine;
using System.Collections;

public static class ExtMonoBehaviour {

    public static float PosX(this MonoBehaviour monoBehaviour) {
        return monoBehaviour.transform.position.x;
    }

    public static float GetGameObject(this MonoBehaviour monoBehaviour) {
        return monoBehaviour.transform.position.x;
    }
}