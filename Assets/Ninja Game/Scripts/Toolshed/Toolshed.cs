using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolshed {

    public static GameObject AddSpeechBubble(string text, Vector3 spawnPos, float duration = 3.0f) {
        GameObject go = Toolbox.Create("Speech Bubble");
        AgentSpeechBubble agentSpeechBubble = go.GetComponent<AgentSpeechBubble>();
        agentSpeechBubble.SetText(text);
        GeneSuicide geneSuicide = go.AddComponent<GeneSuicide>();
        geneSuicide.SetDuration(duration);
        go.transform.position = spawnPos;

        return go;
    }

}
