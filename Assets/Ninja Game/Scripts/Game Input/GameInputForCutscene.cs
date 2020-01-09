using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputForCutscene : GameInput_Base {

    public static readonly GameInputForCutscene I = new GameInputForCutscene();

    private GameInputForCutscene() {}

    public override bool KeyDownForLeft() {
        return false;
    }

    public override bool KeyForLeft() {
        return false;
    }

    public override bool KeyDownForRight() {
        return false;
    }

    public override bool KeyForRight() {
        return false;
    }

    public override bool KeyForCrouch() {
        return false;
    }

    public override bool KeyDownForJump() {
        return false;
    }

    public override bool KeyForJump() {
        return false;
    }

    public override bool KeyDownForThrow() {
        return false;
    }
}
