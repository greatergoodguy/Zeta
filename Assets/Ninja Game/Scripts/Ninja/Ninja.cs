using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NinjaNodeCrouch))]
[RequireComponent(typeof(NinjaNodeCrouchThrow))]
[RequireComponent(typeof(NinjaNodeFall))]
[RequireComponent(typeof(NinjaNodeGlide))]
[RequireComponent(typeof(NinjaNodeIdle))]
[RequireComponent(typeof(NinjaNodeJump))]
[RequireComponent(typeof(NinjaNodeJumpThrow))]
[RequireComponent(typeof(NinjaNodeMock))]
[RequireComponent(typeof(NinjaNodeThrow))]
[RequireComponent(typeof(NinjaNodeWalk))]
[RequireComponent(typeof(NinjaNodeWallJump))]
[RequireComponent(typeof(NinjaNodeWallSlide))]
public class Ninja : MonoBehaviour {

    //public static Ninja I;

    public GameInput_Base gameInput;
    NinjaNode_Base ninjaNode;

    public NinjaNode_Base nodeCrouch;
    public NinjaNode_Base nodeCrouchThrow;
    public NinjaNode_Base nodeFall;
    public NinjaNode_Base nodeGlide;
    public NinjaNode_Base nodeIdle;
    public NinjaNode_Base nodeJump;
    public NinjaNode_Base nodeJumpThrow;
    public NinjaNode_Base nodeMock;
    public NinjaNode_Base nodeThrow;
    public NinjaNode_Base nodeWalk;
    public NinjaNode_Base nodeWallJump;
    public NinjaNode_Base nodeWallSlide;

    public float speed = 5.0f;
    public float jumpForce = 800;
    public float horizontalMovementScalar = 500;
    public float horizontalMaxSpeed = 10;
    public float shurikenHitSFXDelay = 0.25f;

    private bool ignoreLeftInput = false;
    private bool ignoreRightInput = false;

    GameObject goVisualsContainer;
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigidbody2D;

    private static Ninja player;
    public static Ninja GetPlayer() {
        if(player == null) {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Ninja>();
        }
        return player;
    }

    void Awake() {
        nodeCrouch = GetComponent<NinjaNodeCrouch>();
        nodeCrouchThrow = GetComponent<NinjaNodeCrouchThrow>();
        nodeFall = GetComponent<NinjaNodeFall>();
        nodeGlide = GetComponent<NinjaNodeGlide>();
        nodeIdle = GetComponent<NinjaNodeIdle>();
        nodeJump = GetComponent<NinjaNodeJump>();
        nodeJumpThrow = GetComponent<NinjaNodeJumpThrow>();
        nodeMock = GetComponent<NinjaNodeMock>();
        nodeThrow = GetComponent<NinjaNodeThrow>();
        nodeWalk = GetComponent<NinjaNodeWalk>();
        nodeWallJump = GetComponent<NinjaNodeWallJump>();
        nodeWallSlide = GetComponent<NinjaNodeWallSlide>();

        goVisualsContainer = transform.Find("Visuals Container").gameObject;
        _spriteRenderer = goVisualsContainer.GetComponentInChildren<SpriteRenderer>();
        //_rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D = GetComponentInChildren<Rigidbody2D>();

        //I = this;
    }

    void Start() {
        gameInput = GameInputForUser.I;
        ninjaNode = nodeIdle;
        ninjaNode.EnterNode();
        ninjaNode.IsActive = true;
        Toolbox.Log(ninjaNode.GetType().Name + ": Enter");
    }

    void Update() {

        ninjaNode.UpdateNode();

        if (gameInput.KeyDownForLeft() && !ignoreLeftInput) {
            FaceLeft();
        }
        if (gameInput.KeyDownForRight() && !ignoreRightInput) {
            FaceRight();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Vector3 newPosition = new Vector3(-4.6f, 39f, transform.position.z);
            transform.position = newPosition;
        }
    }

    public void SetGameInput(GameInput_Base _gameInput) {
        gameInput = _gameInput;
    }

    public void EnableGameInputForUser() {
        SetGameInput(GameInputForUser.I);
    }

    public void DisableGameInput() {
        SetGameInput(GameInputMock.I);
    }

    public void FaceLeft() {
        goVisualsContainer.transform.localPosition = new Vector2(-1.22f, 0);
        _spriteRenderer.flipX = true;
    }

    public void FaceRight() {
        goVisualsContainer.transform.localPosition = new Vector2(0, 0);
        _spriteRenderer.flipX = false;
    }

    void FixedUpdate() {
        ninjaNode.FixedUpdateNode();

        MoveHorizontal();
    }

    public void SwitchNode(NinjaNode_Base _ninjaNode) {
        ninjaNode.ExitNode();
        ninjaNode.IsActive = false;
        Toolbox.Log(ninjaNode.GetType().Name + ": Exit");

        ninjaNode = _ninjaNode;
        ninjaNode.EnterNode();
        ninjaNode.IsActive = true;
        Toolbox.Log(ninjaNode.GetType().Name + ": Enter");
    }

    public void SetAnimation(int animation) {
        goVisualsContainer.GetComponentInChildren<Animator>().SetInteger("animation", animation);
    }

    public Vector3 GetVelocity() {
        return GetComponent<Rigidbody2D>().velocity;
    }

    public void MoveHorizontal() {
        if (Math.Abs(_rigidbody2D.velocity.x) < horizontalMaxSpeed) {
            if (gameInput.KeyForLeft() && !ignoreLeftInput) {
                if (!isFacingLeft()) {
                    FaceLeft();
                }
                Vector2 movement = new Vector2(-1, 0);
                Vector2 horizontalForce = horizontalMovementScalar * movement;
                _rigidbody2D.AddForce(horizontalForce);
            }
            if (gameInput.KeyForRight() && !ignoreRightInput) {
                if (isFacingLeft()) {
                    FaceRight();
                }
                Vector2 movement = new Vector2(1, 0);
                Vector2 horizontalForce = horizontalMovementScalar * movement;
                _rigidbody2D.AddForce(horizontalForce);
            }
        }
    }

    public void WalkIfInput() {
        if ((gameInput.KeyForLeft() || gameInput.KeyForRight())) {
            SwitchNode(nodeWalk);
        }
    }

    public void JumpIfInput() {
        if (gameInput.KeyDownForJump()) {
            SwitchNode(nodeJump);
        }
    }

    public void WallJumpIfInput() {
        if (gameInput.KeyDownForJump()) {
            SwitchNode(nodeWallJump);
        }
    }

    public void ThrowIfInput() {
        if (gameInput.KeyDownForThrow()) {
            Throw();
        }
    }

    public void JumpThrowIfInput() {
        if (gameInput.KeyDownForThrow()) {
            SwitchNode(nodeJumpThrow);
        }
    }

    public void GlideIfInput() {
        if (gameInput.KeyDownForJump()) {
            SwitchNode(nodeGlide);
        }
    }

    public void CancelGlideIfInput() {
        if (!gameInput.KeyForGlide()) {
            SwitchNode(nodeFall);
        }
    }

    public void Throw() {
        SwitchNode(nodeThrow);
    }

    public void CrouchIfInput() {
        if (gameInput.KeyForCrouch()) {
            SwitchNode(nodeCrouch);
        }
    }

    public void CrouchThrowIfInput() {
        if (gameInput.KeyDownForThrow()) {
            SwitchNode(nodeCrouchThrow);
        }
    }

    public void IdleIfInput() {
        if (!gameInput.KeyForLeft() && !gameInput.KeyForRight()) {
            SwitchNode(nodeIdle);
        }
    }

    public void ThrowShuriken() {
        GameObject goShuriken = Toolbox.Create("Shuriken");
        goShuriken.transform.position = transform.position;
        AgentShuriken shuriken = goShuriken.GetComponent<AgentShuriken>();

        if (isFacingLeft()) {
            shuriken.LaunchLeft();
        }
        else {
            shuriken.LaunchRight();
        }

        ActorSFXManager.I.Play(ActorSFXManager.ShurikenThrow);
    }

    public bool isFacingLeft() {
        return _spriteRenderer.flipX == true;
    }

    public void SetIgnoreLeftInput(bool _ignoreLeftInput) {
        ignoreLeftInput = _ignoreLeftInput;
    }

    public void SetIgnoreRightInput(bool _ignoreRightInput) {
        ignoreRightInput = _ignoreRightInput;
    }
}