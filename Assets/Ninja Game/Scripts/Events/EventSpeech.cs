using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSpeech : Event_Base {

    public const float DURATION_SHORT = 1.0f;
    public const float DURATION_NORMAL = 2.0f;
    public const float DURATION_LONG = 5.0f;
    public const float TIME_BETWEEN_CHARACTERS = 0.01f;

    GameObject target;
    string dialogue;
    float duration;
    bool isSkippable;

    GameObject goSpeech;

    public EventSpeech(GameObject target, string dialogue, float duration = DURATION_NORMAL, bool isSkippable = true) {
        this.target = target;
        this.dialogue = dialogue;
        this.duration = duration;
        this.isSkippable = isSkippable;
    }

    public override IEnumerator ProcessCoroutine() {
        float speechBubbleDuration = duration + 0.1f + dialogue.Length * TIME_BETWEEN_CHARACTERS;
        goSpeech = Toolshed.AddSpeechBubble("Hello World", target.transform, speechBubbleDuration);
        AgentSpeechBubble agentSpeechBubble = goSpeech.GetComponent<AgentSpeechBubble>();

        string sentence = "";
        foreach (char letter in dialogue.ToCharArray()) {
            sentence += letter;
            agentSpeechBubble.SetText(Toolbox.PadString(dialogue, sentence));
            yield return new WaitForSeconds(TIME_BETWEEN_CHARACTERS);
        }
    }

    public override void ProcessComplete() {
        AgentSpeechBubble agentSpeechBubble = goSpeech.GetComponent<AgentSpeechBubble>();
        agentSpeechBubble.SetText(dialogue);
    }

    public override void CleanUp() {
        Object.Destroy(goSpeech);
    }

    public override float GetDuration() { return duration; }

    public override bool IsSkippable() { return isSkippable; }
}
