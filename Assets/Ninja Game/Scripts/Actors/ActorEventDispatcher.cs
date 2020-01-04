using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorEventDispatcher : MonoBehaviour {

    public static ActorEventDispatcher I;

    List<Event_Base> events;
    Event_Base currEvent;

    bool isEventOccuring;
    bool isEventProcessing;

    void Awake() {
        I = this;

        events = new List<Event_Base>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightShift)) {
            ButtonFullScreen();
        }
    }

    public void AddEvent(Event_Base newEvent) {
        events.Add(newEvent);

        if (!isEventOccuring) {
            ProcessNextEvent();
        }
    }

    void ProcessNextEvent() {
        StopAllCoroutines();
        if (events.Count == 0) {
            isEventOccuring = false;
            return;
        }

        isEventOccuring = true;
        currEvent = events[0];
        events.RemoveAt(0);

        StartCoroutine(ProcessingCoroutine(currEvent));
    }

    IEnumerator ProcessingCoroutine(Event_Base _currEvent) {
        isEventProcessing = true;
        yield return _currEvent.ProcessCoroutine();
        isEventProcessing = false;

        StartCoroutine(ProcessCompletedCoroutine(currEvent));
    }

    IEnumerator ProcessCompletedCoroutine(Event_Base _currEvent) {
        _currEvent.ProcessComplete();
        yield return new WaitForSeconds(_currEvent.GetDuration());

        if (events.Count == 0) {
            isEventOccuring = false;
        }
        else {
            _currEvent.CleanUp();
            ProcessNextEvent();
        }
    }

    public void Clear() {
        events.Clear();
        StopAllCoroutines();
        isEventOccuring = false;
        isEventProcessing = false;
    }

    public bool AreAllEventsFinished() {
        return events.Count == 0 && !isEventOccuring && !isEventProcessing;
    }

    public void TurnButtonOff() {
        transform.Find("Button Full Screen").gameObject.SetActive(false);
    }

    public void TurnButtonOn() {
        transform.Find("Button Full Screen").gameObject.SetActive(true);
    }

    // ==================
    // Button Callbacks
    // ==================
    public void ButtonFullScreen() {
        if (events.Count == 0 && !isEventProcessing) {
            return;
        }

        if (currEvent != null && !currEvent.IsSkippable()) {
            return;
        }

        if (isEventProcessing) {
            isEventProcessing = false;
            StopAllCoroutines();
            StartCoroutine(ProcessCompletedCoroutine(currEvent));
        }
        else {
            StopAllCoroutines();
            currEvent.CleanUp();
            ProcessNextEvent();
        }
    }
}
