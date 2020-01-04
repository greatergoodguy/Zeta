using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSetNinjaAnimation: Event_Base {

    GameObject target;
    int animation;

    public EventSetNinjaAnimation(GameObject target, int animation) {
        this.target = target;
        this.animation = animation;
    }

    public override IEnumerator ProcessCoroutine() {
        target.GetComponent<Animator>().SetInteger("animation", animation);
        return null;
    }

    public override float GetDuration() { return 0.01f; }
}
