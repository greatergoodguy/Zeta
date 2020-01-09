using UnityEngine;
using System;
using System.Collections;

public static class ExtMonoBehaviour {

    public static float PosX(this MonoBehaviour monoBehaviour) {
        return monoBehaviour.transform.position.x;
    }

    public static float GetGameObject(this MonoBehaviour monoBehaviour) {
        return monoBehaviour.transform.position.x;
    }


    // ==================
    // Event Helpers
    // ==================
    public static void AddEvent(this MonoBehaviour monoBehaviour, Event_Base _event) {
        ActorEventDispatcher.I.AddEvent(_event);
    }

    public static void AddEvent(this MonoBehaviour monoBehaviour, Action action, float duration = EventAction.DEFAULT_DURATION) {
        ActorEventDispatcher.I.AddEvent(new EventAction(action, duration));
    }
}