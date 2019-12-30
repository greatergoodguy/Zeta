using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MasterScript : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        ActorMusicManager.I.PlayInstant(0);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
