using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAction : Event_Base {

    public const float DEFAULT_DURATION = 0.01f;

    Action action;
    float duration;

    public EventAction(Action action, float duration = DEFAULT_DURATION) {
        this.action = action;
        this.duration = duration;
    }

    public override IEnumerator ProcessCoroutine() {
        action.Invoke();
        return null;
    }

    public override float GetDuration() { return duration; }
}