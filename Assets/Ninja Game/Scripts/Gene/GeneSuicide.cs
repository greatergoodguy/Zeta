using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneSuicide : MonoBehaviour {

    public float duration = 5;

    private float elapsedTime;

    public void SetDuration(float duration) {
        this.duration = duration;
    }

    // Update is called once per frame
    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > duration) {
            Destroy(gameObject);
        }
    }
}