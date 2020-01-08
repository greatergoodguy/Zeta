using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFadeOut : Event_Base {

    public static EventFadeOut I = new EventFadeOut();

    readonly float FADE_DURATION = 3.0f;
    readonly float EVENT_DURATION = 3.0f;

    Action actionOnFinish;

    private EventFadeOut() {}

    public EventFadeOut(Action actionOnFinish) {
        this.actionOnFinish = actionOnFinish;
    }

    public override IEnumerator ProcessCoroutine() {
        ActorWidgets.I.FadeOut(FADE_DURATION);
        if (actionOnFinish == null) {
            ActorWidgets.I.FadeOut(FADE_DURATION);
        }
        else {
            ActorWidgets.I.FadeOut(actionOnFinish, FADE_DURATION);
        }
        yield return null;
    }

    public override float GetDuration() { return EVENT_DURATION; }
}