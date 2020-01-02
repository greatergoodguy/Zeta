using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class GeneShowSpeechBubble : MonoBehaviour {

    public string speech;

    GameObject goSpeechBubble;

    bool isTriggered;

    void Update() {
        if (isTriggered && Input.GetKeyDown(KeyCode.RightShift) && goSpeechBubble == null) {
            goSpeechBubble = Toolshed.AddSpeechBubble(speech, transform);
        }
        else if (isTriggered && Input.GetKeyDown(KeyCode.RightShift) && goSpeechBubble != null) {
            CleanUp();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            if (speech == null) {
                speech = "";
            }

            isTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            isTriggered = false;
        }
        CleanUp();
    }

    void CleanUp() {
        Destroy(goSpeechBubble);
        goSpeechBubble = null;
    }
}