using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class _MasterScript : MonoBehaviour {

    public static _MasterScript I;

    public SeTi_Base seasonOfTime;

    void Awake() {
        I = this;
    }

    // Start is called before the first frame update
    void Start() {
        Toolbox.Log("Start()");
        if(seasonOfTime == null) {
            seasonOfTime = SetiMock.I;
        }
        seasonOfTime.Enter();
        Toolbox.Log(seasonOfTime.GetType().Name + ": Enter");
    }

    // Update is called once per frame
    void Update() {
        seasonOfTime.UpdateSeason();
    }

    public void SwitchSeason(SeTi_Base _seasonOfTime) {
        seasonOfTime.Exit();
        Toolbox.Log(seasonOfTime.GetType().Name + ": Exit");

        seasonOfTime = _seasonOfTime;
        seasonOfTime.Enter();
        Toolbox.Log(seasonOfTime.GetType().Name + ": Enter");
    }
}
