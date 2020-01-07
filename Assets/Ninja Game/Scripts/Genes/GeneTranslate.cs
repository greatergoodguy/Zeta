using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneTranslate : MonoBehaviour {

    public const float DEFAULT_SPEED = 30.0f;

    public Vector3 direction = Vector3.right;
    public float speed = DEFAULT_SPEED;

    float elapsedTime;

    public void Init(Vector3 direction, float speed = DEFAULT_SPEED) {
        this.direction = direction;
        this.speed = speed;
    }

    // Update is called once per frame
    void Update() {
        elapsedTime += Time.deltaTime;

        transform.Translate(direction * Time.deltaTime * speed);
    }
}