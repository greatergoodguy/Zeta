using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput_Base {
    public virtual bool KeyDownForLeft()    { return false; }
    public virtual bool KeyForLeft()        { return false; }
    public virtual bool KeyUpForLeft()      { return false; }
    public virtual bool KeyDownForRight()   { return false; }
    public virtual bool KeyForRight()       { return false; }
    public virtual bool KeyUpForRight()     { return false; }
    public virtual bool KeyForCrouch()      { return false; }
    public virtual bool KeyDownForJump()    { return false; }
    public virtual bool KeyForJump()        { return false; }
    public virtual bool KeyForGlide()       { return false; }
    public virtual bool KeyDownForThrow()   { return false; }
}
