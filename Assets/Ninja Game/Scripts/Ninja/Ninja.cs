﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NinjaNodeMock))]
[RequireComponent(typeof(NinjaNodeIdle))]
public class Ninja : MonoBehaviour {

    public static Ninja I;


    GameInput_Base gameInput;
    NinjaNode_Base ninjaNode;

    public float speed = 5.0f;
    public float jumpForce = 800;
    public float horizontalMovementScalar = 500;
    public float horizontalMaxSpeed = 10;
    public float shurikenHitSFXDelay = 0.25f;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigidbody2D;

    bool controlsEnabled = true;
    void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        I = this;
    }

    void Start() {
        gameInput = GameInputForUser.I;
        ninjaNode = NinjaNodeIdle.I;
        ninjaNode.EnterNode();
        Toolbox.Log(ninjaNode.GetType().Name + ": Enter");
    }

    void Update() {

        ninjaNode.UpdateNode();

        if (gameInput.KeyDownForLeft() && controlsEnabled) {
            FaceLeft();
        }
        if (gameInput.KeyDownForRight() && controlsEnabled) {
            FaceRight();
        }

        if(transform.position.y < -10) {
            Vector3 newPosition = new Vector3(transform.position.x, 15, transform.position.z);
            transform.position = newPosition;
        }
    }

    public void EnableControls() {
        controlsEnabled = true;
    }

    public void DisableControls() {
        controlsEnabled = false;
    }

    public void FaceLeft() {
        _spriteRenderer.flipX = true;
    }

    public void FaceRight() {
        _spriteRenderer.flipX = false;
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
            if (gameInput.KeyForLeft() && controlsEnabled) {
                Vector2 movement = new Vector2(-1, 0);
                Vector2 horizontalForce = horizontalMovementScalar * movement;
                _rigidbody2D.AddForce(horizontalForce);
            }
            if (gameInput.KeyForRight() && controlsEnabled) {
                Vector2 movement = new Vector2(1, 0);
                Vector2 horizontalForce = horizontalMovementScalar * movement;
                _rigidbody2D.AddForce(horizontalForce);
            }
        }
    }

    public void WalkIfInput() {
        if ((gameInput.KeyForLeft() || gameInput.KeyForRight()) && controlsEnabled) {
            SwitchNode(NinjaNodeWalk.I);
        }
    }

    public void JumpIfInput() {
        if (gameInput.KeyForJump() && controlsEnabled) {
            SwitchNode(NinjaNodeJump.I);
        }
    }

    public void ThrowIfInput() {
        if (gameInput.KeyDownForThrow() && controlsEnabled) {
            Throw();
        }
    }

    public void JumpThrowIfInput() {
        if (gameInput.KeyDownForThrow() && controlsEnabled) {
            SwitchNode(NinjaNodeJumpThrow.I);
        }
    }

    public void Throw() {
        SwitchNode(NinjaNodeThrow.I);
    }

    public void CrouchIfInput() {
        if (gameInput.KeyForCrouch() && controlsEnabled) {
            SwitchNode(NinjaNodeCrouch.I);
        }
    }

    public void CrouchThrowIfInput() {
        if (gameInput.KeyDownForThrow() && controlsEnabled) {
            SwitchNode(NinjaNodeCrouchThrow.I);
        }
    }

    public void ThrowShuriken() {
        ActorSFXManager.I.Play(0);

        GameObject goShuriken = Toolbox.Create("Shuriken");
        goShuriken.transform.position = transform.position;
        AgentShuriken shuriken = goShuriken.GetComponent<AgentShuriken>();
        
        if(isFacingLeft()) {
            shuriken.LaunchLeft();
        } else {
            shuriken.LaunchRight();
        }
    }

    bool isFacingLeft() {
        return _spriteRenderer.flipX == true;
    }
}