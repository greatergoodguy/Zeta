using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorWidgets : MonoBehaviour {

    public static ActorWidgets I;

    void Awake() {
        I = this;
    }

    // =======================================
    // Fade
    // =======================================
    private const float DEFAULT_FADE_DURATION = 3.0f;
    public void FadeIn(float duration = DEFAULT_FADE_DURATION) {
        StartCoroutine(FadeCoroutine(() => { }, 1.0f, 0.0f, duration));
    }

    public void FadeIn(Action actionOnFinish, float duration = DEFAULT_FADE_DURATION) {
        StartCoroutine(FadeCoroutine(actionOnFinish, 1.0f, 0.0f, duration));
    }

    public void FadeOut(float duration = DEFAULT_FADE_DURATION) {
        StartCoroutine(FadeCoroutine(() => {}, 0.0f, 1.0f, duration));
    }

    public void FadeOut(Action actionOnFinish, float duration = DEFAULT_FADE_DURATION) {
        Image imageBlack = transform.Find("Canvas/Black").GetComponent<Image>();
        imageBlack.color = Color.clear;
        StartCoroutine(FadeCoroutine(actionOnFinish, 0.0f, 1.0f, duration));
    }

    private IEnumerator FadeCoroutine(Action actionOnFinish, float alphaStart, float alphaEnd, float duration = DEFAULT_FADE_DURATION) {
        GameObject goScreenBlocker = transform.Find("Canvas/Screen Blocker").gameObject;
        GameObject goBlack = transform.Find("Canvas/Black").gameObject;

        Destroy(goBlack.GetComponent<GeneImageFadeAlpha>());
        GeneImageFadeAlpha gene = goBlack.AddComponent<GeneImageFadeAlpha>();
        gene.Init(duration, alphaStart, alphaEnd);

        goScreenBlocker.SetActive(true);
        goBlack.SetActive(true);
        yield return new WaitForSeconds(duration);
        goScreenBlocker.SetActive(false);
        goBlack.SetActive(false);
        actionOnFinish.Invoke();
    }
}
