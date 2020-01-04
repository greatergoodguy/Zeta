
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorTitleScreen : MonoBehaviour {

    public static ActorTitleScreen I;

    GameObject goPanel;
    GameObject goBlocker;

    void Awake() {
        I = this;

        goPanel = transform.Find("Panel").gameObject;
        goBlocker = goPanel.transform.Find("Blocker").gameObject;
    }

    // Start is called before the first frame update
    void Start() {
        HidePanel();
    }

    public void EnableUI() {
        goBlocker.SetActive(false);
    }

    public void DisableUI() {
        goBlocker.SetActive(true);
    }

    public void ShowPanel() {
        goPanel.SetActive(true);
    }

    public void HidePanel() {
        goPanel.SetActive(false);
    }
}
