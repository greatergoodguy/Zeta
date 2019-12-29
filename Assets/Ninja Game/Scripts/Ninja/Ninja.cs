using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NinjaNodeMock))]
[RequireComponent(typeof(NinjaNodeIdle))]
public class Ninja : MonoBehaviour {

    public static Ninja I;

    NinjaNode_Base ninjaNode;

    public float speed = 5.0f;
    public float jumpForce = 800;

    void Awake() {
        I = this;
    }

    void Start() {
        ninjaNode = NinjaNodeIdle.I;
        ninjaNode.EnterNode();
        Toolbox.Log(ninjaNode.GetType().Name + ": Enter");
    }

    void Update() {

        ninjaNode.UpdateNode();

        testAnimations();

        if (Input.GetKeyDown(KeyCode.A)) {
            // Face Left
            transform.localScale = new Vector3(-1, 1, 1);

        }
        if (Input.GetKeyDown(KeyCode.D)) {
            // Face Right
            transform.localScale = new Vector3(1, 1, 1);
        }
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

    public void SwitchNode(NinjaNode_Base _ninjaNode) {
        ninjaNode.ExitNode();
        Toolbox.Log(ninjaNode.GetType().Name + ": Exit");

        ninjaNode = _ninjaNode;
        ninjaNode.EnterNode();
        Toolbox.Log(ninjaNode.GetType().Name + ": Enter");
    }

    public void SetAnimation(int animation) {
        GetComponent<Animator>().SetInteger("animation", animation);
    }

    public Vector3 GetVelocity() {
        return GetComponent<Rigidbody2D>().velocity;
    }
}