using UnityEngine;
using System;
using System.Collections;

public abstract class SeTi_Base : MonoBehaviour {

    public virtual void Enter() { }
    public virtual void UpdateSeason() { }
    public virtual void Exit() {}

    protected void SwitchSeason(SeTi_Base newSeason) {
        _MasterScript.I.SwitchSeason(newSeason);
    }

    // ==================
    // Event Helpers
    // ==================
    protected void AddEvent(Event_Base _event) {
        ActorEventDispatcher.I.AddEvent(_event);
    }

    protected void AddEvent(Action action, float duration = EventAction.DEFAULT_DURATION) {
        ActorEventDispatcher.I.AddEvent(new EventAction(action));
    }
}