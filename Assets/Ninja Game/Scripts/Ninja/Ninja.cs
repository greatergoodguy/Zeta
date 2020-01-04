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
    public float shurikenHitSFXDelay = 0.25f;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigidbody2D;

    bool controlsEnabled = true;

    public void EnableControls() {
        controlsEnabled = true;
    }

    public void DisableControls() {
        controlsEnabled = false;
    }

    void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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

        if (Input.GetKeyDown(KeyCode.A) && controlsEnabled) {
            // Face Left
            //transform.localScale = new Vector3(-1, 1, 1);
            _spriteRenderer.flipX = true;

        }
        if (Input.GetKeyDown(KeyCode.D) && controlsEnabled) {
            // Face Right
            //transform.localScale = new Vector3(1, 1, 1);
            _spriteRenderer.flipX = false;
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
        if (Math.Abs(_rigidbody2D.velocity.x) < horizontalMaxSpeed) {
            if (Input.GetKey(KeyCode.A) && controlsEnabled) {
                Vector2 movement = new Vector2(-1, 0);
                Vector2 horizontalForce = horizontalMovementScalar * movement;
                _rigidbody2D.AddForce(horizontalForce);
            }
            if (Input.GetKey(KeyCode.D) && controlsEnabled) {
                Vector2 movement = new Vector2(1, 0);
                Vector2 horizontalForce = horizontalMovementScalar * movement;
                _rigidbody2D.AddForce(horizontalForce);
            }
        }
    }

    public void WalkIfInput() {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && controlsEnabled) {
            SwitchNode(NinjaNodeWalk.I);
        }
    }

    public void JumpIfInput() {
        if (Input.GetKey(KeyCode.Space) && controlsEnabled) {
            SwitchNode(NinjaNodeJump.I);
        }
    }

    public void ThrowIfInput() {
        if (Input.GetKey(KeyCode.LeftShift) && controlsEnabled) {
            Throw();
        }
    }

    public void JumpThrowIfInput() {
        if (Input.GetKeyDown(KeyCode.LeftShift) && controlsEnabled) {
            SwitchNode(NinjaNodeJumpThrow.I);
        }
    }

    public void Throw() {
        SwitchNode(NinjaNodeThrow.I);
    }

    public void CrouchIfInput() {
        if (Input.GetKey(KeyCode.S) && controlsEnabled) {
            SwitchNode(NinjaNodeCrouch.I);
        }
    }

    public void CrouchThrowIfInput() {
        if (Input.GetKey(KeyCode.LeftShift) && controlsEnabled) {
            SwitchNode(NinjaNodeCrouchThrow.I);
        }
    }

    public void ThrowShuriken() {
        ActorSFXManager.I.Play(0);
        Invoke("ShurikenHitSFX", shurikenHitSFXDelay);
    }

    void ShurikenHitSFX() {
        ActorSFXManager.I.Play(1);
    }

}