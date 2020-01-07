using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolshed {

    public static GameObject AddSpeechBubble(string text, Transform target, float duration = 3.0f) {
        Vector3 offset = new Vector3(0.01f, 4f, 0);

        GameObject go = Toolbox.Create("Speech Bubble");
        AgentSpeechBubble agentSpeechBubble = go.GetComponent<AgentSpeechBubble>();
        agentSpeechBubble.SetText(text);
        GeneSuicide geneSuicide = go.AddComponent<GeneSuicide>();
        geneSuicide.SetDuration(duration);
        go.transform.parent = target;
        go.transform.localPosition = offset;

        return go;
    }

}
