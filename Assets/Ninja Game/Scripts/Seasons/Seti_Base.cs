
using UnityEngine;
using System.Collections;

public abstract class SeTi_Base : MonoBehaviour {

    public virtual void Enter() { }
    public virtual void UpdateSeason() { }
    public virtual void Exit() {}

    protected void SwitchSeason(SeTi_Base newSeason) {
        _MasterScript.I.SwitchSeason(newSeason);
    }

}