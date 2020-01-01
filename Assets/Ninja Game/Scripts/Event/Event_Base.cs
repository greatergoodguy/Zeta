using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Base {


    public virtual IEnumerator ProcessCoroutine() {
        yield return null;
    }
    public virtual void ProcessComplete() { }
    public virtual void CleanUp() { }

    public virtual float GetDuration() { return 2.0f; }
    public virtual bool IsSkippable() { return false; }
}
