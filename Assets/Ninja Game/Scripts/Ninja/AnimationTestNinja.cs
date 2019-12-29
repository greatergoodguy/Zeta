using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTestNinja : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        testAnimations();
    }

    int i = 1;
    private void testAnimations() {
        Animator animator = GetComponent<Animator>();

        if (Input.GetKeyDown(KeyCode.Q)) {
            i = 0;
        }
        else if (Input.GetKeyDown(KeyCode.E)) {
            i = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            animator.SetInteger("animation", i * 10 + 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1)) {
            animator.SetInteger("animation", i * 10 + 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            animator.SetInteger("animation", i * 10 + 2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            animator.SetInteger("animation", i * 10 + 3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            animator.SetInteger("animation", i * 10 + 4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) {
            animator.SetInteger("animation", i * 10 + 5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6)) {
            animator.SetInteger("animation", i * 10 + 6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7)) {
            animator.SetInteger("animation", i * 10 + 7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8)) {
            animator.SetInteger("animation", i * 10 + 8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9)) {
            animator.SetInteger("animation", i * 10 + 9);
        }
    }

}
