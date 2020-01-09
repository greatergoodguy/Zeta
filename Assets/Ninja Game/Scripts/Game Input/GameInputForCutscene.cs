using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputForCutscene : GameInput_Base {

    public static readonly GameInputForCutscene I = new GameInputForCutscene();

    private GameInputForCutscene() {}

    public bool _KeyDownForLeft { get; set; }
    public override bool KeyDownForLeft() {
        return _KeyDownForLeft;
    }

    public bool _KeyForLeft { get; set; }
    public override bool KeyForLeft() {
        return _KeyForLeft;
    }

    public bool _KeyDownForRight { get; set; }
    public override bool KeyDownForRight() {
        return _KeyDownForRight;
    }

    public bool _KeyForRight { get; set; }
    public override bool KeyForRight() {
        return _KeyForRight;
    }

    public bool _KeyForCrouch { get; set; }
    public override bool KeyForCrouch() {
        return _KeyForCrouch;
    }

    public bool _KeyDownForJump { get; set; }
    public override bool KeyDownForJump() {
        return _KeyDownForJump;
    }

    public bool _KeyForJump { get; set; }
    public override bool KeyForJump() {
        return _KeyForJump;
    }

    public bool _KeyDownForThrow { get; set; }
    public override bool KeyDownForThrow() {
        return _KeyDownForThrow;
    }
}
