using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFadeIn : Event_Base {

    public static EventFadeIn I = new EventFadeIn();

    readonly float FADE_DURATION = 3.0f;
    readonly float EVENT_DURATION = 3.0f;

    Action actionOnFinish;

    private EventFadeIn() {}

    public EventFadeIn(Action actionOnFinish) {
        this.actionOnFinish = actionOnFinish;
    }

    public override IEnumerator ProcessCoroutine() {
        if(actionOnFinish == null) {
            ActorWidgets.I.FadeIn(FADE_DURATION);
        } else {
            ActorWidgets.I.FadeIn(actionOnFinish, FADE_DURATION);
        }
        yield return null;
    }

    public override float GetDuration() { return EVENT_DURATION; }
}