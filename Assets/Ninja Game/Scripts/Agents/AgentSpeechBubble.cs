using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AgentSpeechBubble : MonoBehaviour {

    TextMeshProUGUI text;

    void Awake() {
        text = transform.Find("Panel/Text").GetComponent<TextMeshProUGUI>();
    }

    // We slowly move the speech bubble backwards 
    // so new ones will overlay on top of the old ones
    public void Update() {
        transform.Translate(0, 0, 0.1f * Time.deltaTime);
    }

    public void SetText(string newText) {
        text.text = newText;
    }

    public TextMeshProUGUI GetText() {
        return text;
    }
}
