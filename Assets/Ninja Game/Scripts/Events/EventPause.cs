using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPause : Event_Base {

    public const float DURATION_VERY_SHORT = 0.5f;
    public const float DURATION_SHORT = 1.0f;
    public const float DURATION_NORMAL = 2.0f;

    float duration;
    bool isSkippable;

    public EventPause(float duration = DURATION_NORMAL, bool isSkippable = true) {
        this.duration = duration;
        this.isSkippable = isSkippable;
    }

    public override float GetDuration() { return duration; }

    public override bool IsSkippable() { return isSkippable; }
}