using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFadeOut : Event_Base {

    public static EventFadeOut I = new EventFadeOut();

    readonly float FADE_DURATION = 1.0f;
    readonly float EVENT_DURATION = 2.0f;

    private EventFadeOut() {}

    public override IEnumerator ProcessCoroutine() {
        ActorWidgets.I.FadeOut(FADE_DURATION);
        yield return null;
    }

    public override float GetDuration() { return EVENT_DURATION; }
}