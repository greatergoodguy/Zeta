using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1SkipTarget : MonoBehaviour {

    Stage1 stage1;

    // Start is called before the first frame update
    void Start() {
        stage1 = Stage1.I;
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            stage1.OnSkipTarget();
        }
    }
}
