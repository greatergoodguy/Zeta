using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GeneFadeAlpha : MonoBehaviour {

    Image image;

    float duration = 5.0f;
    float alphaStart = 0.0f;
    float alphaEnd = 1.0f;
    float elapsedTime;

    public void Init(float duration, float alphaStart, float alphaEnd) {
        this.duration = duration;
        this.alphaStart = alphaStart;
        this.alphaEnd = alphaEnd;
    }

    void Awake() {
        image = GetComponent<Image>();
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (elapsedTime > duration) {
            Destroy(this);
            return;
        }

        elapsedTime += Time.deltaTime;
        float frac = elapsedTime / duration;
        Color tempColor = image.color;
        tempColor.a = Mathf.Lerp(alphaStart, alphaEnd, frac);
        image.color = tempColor;
    }
}