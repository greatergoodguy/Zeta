using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFadeIn : Event_Base {

    public static EventFadeIn I = new EventFadeIn();

    readonly float FADE_DURATION = 3.0f;
    readonly float EVENT_DURATION = 3.0f;

    private EventFadeIn() {}

    public override IEnumerator ProcessCoroutine() {
        ActorWidgets.I.FadeIn(FADE_DURATION);
        yield return null;
    }

    public override float GetDuration() { return EVENT_DURATION; }
}