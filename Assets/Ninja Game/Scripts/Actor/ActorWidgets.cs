using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorWidgets : MonoBehaviour {

    public static ActorWidgets I;

    void Awake() {
        I = this;
    }

    // =======================================
    // Fade
    // =======================================
    public void FadeIn(float duration = 1.0f) {
        StartCoroutine(FadeInCoroutine(() => {}, duration));
    }

    public void FadeIn(Action actionOnFinish, float duration = 1.0f) {
        StartCoroutine(FadeInCoroutine(actionOnFinish, duration));
    }

    private IEnumerator FadeInCoroutine(Action actionOnFinish, float duration = 1.0f) {
        GameObject goScreenBlocker = transform.Find("Canvas/Screen Blocker").gameObject;
        GameObject goBlack = transform.Find("Canvas/Black").gameObject;

        Destroy(goBlack.GetComponent<GeneFadeAlpha>());
        GeneFadeAlpha gene = goBlack.AddComponent<GeneFadeAlpha>();
        gene.Init(duration, 0.0f, 1.0f);

        goScreenBlocker.SetActive(true);
        goBlack.SetActive(true);
        yield return new WaitForSeconds(duration);
        goScreenBlocker.SetActive(false);
        goBlack.SetActive(false);
        actionOnFinish.Invoke();
    }
}
