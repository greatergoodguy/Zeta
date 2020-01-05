using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneRotate: MonoBehaviour {
    private const float DEFAULT_SPEED = 500.0f;

	public float speed = DEFAULT_SPEED;
    public bool isClockwise;


    float elapsedTime;

	public void Init(bool isClockwise, float speed = DEFAULT_SPEED) {
        this.isClockwise = isClockwise;
        this.speed = speed;
    }

	// Update is called once per frame
	void Update() {
		elapsedTime += Time.deltaTime;

        if(isClockwise) {
            transform.Rotate(0, 0, speed * Time.deltaTime * -1);
        } else {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
    }
}