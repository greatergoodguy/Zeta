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
    public float horizontalMovementScalar = 500;
    public float horizontalMaxSpeed = 10;

    Rigidbody2D _rigidbody2D;

    void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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

        if(transform.position.y < -10) {
            Vector3 newPosition = new Vector3(transform.position.x, 15, transform.position.z);
            transform.position = newPosition;
        }
    }

    void FixedUpdate() {
        ninjaNode.FixedUpdateNode();

        MoveHorizontal();
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

    public void MoveHorizontal() {
        //float xMovement = Input.GetAxis("Horizontal");
        ////if (Math.Abs(_rigidbody2D.velocity.x) < horizontalMaxSpeed && Math.Abs(xMovement) > 0.9f) {
        //if (Math.Abs(_rigidbody2D.velocity.x) < horizontalMaxSpeed) {
        //    Vector2 movement = new Vector2(xMovement, 0);
        //    Vector2 horizontalForce = horizontalMovementScalar * movement;
        //    _rigidbody2D.AddForce(horizontalForce);
        //}

        if (Math.Abs(_rigidbody2D.velocity.x) < horizontalMaxSpeed) {
            if (Input.GetKey(KeyCode.A)) {
                Vector2 movement = new Vector2(-1, 0);
                Vector2 horizontalForce = horizontalMovementScalar * movement;
                _rigidbody2D.AddForce(horizontalForce);
            }
            if (Input.GetKey(KeyCode.D)) {
                Vector2 movement = new Vector2(1, 0);
                Vector2 horizontalForce = horizontalMovementScalar * movement;
                _rigidbody2D.AddForce(horizontalForce);
            }
        }
    }
}