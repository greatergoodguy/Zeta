﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentShuriken : MonoBehaviour {

    GameObject goSprite;

    GeneRotate geneRotate;
    GeneTranslate geneTranslate;
    GeneSuicide geneSuicide;

    void Awake() {
        goSprite = transform.Find("Sprite").gameObject;
    }

    public void LaunchLeft() {
        Destroy(geneRotate);
        geneRotate = goSprite.AddComponent<GeneRotate>();
        geneRotate.Init(false);

        Destroy(geneTranslate);
        geneTranslate = gameObject.AddComponent<GeneTranslate>();
        geneTranslate.Init(Vector3.left);

        Destroy(geneSuicide);
        geneSuicide = gameObject.AddComponent<GeneSuicide>();
        geneSuicide.SetDuration(10.0f);
    }

    public void LaunchRight() {
        Destroy(geneRotate);
        geneRotate = goSprite.AddComponent<GeneRotate>();
        geneRotate.Init(true);

        Destroy(geneTranslate);
        geneTranslate = gameObject.AddComponent<GeneTranslate>();

        Destroy(geneSuicide);
        geneSuicide = gameObject.AddComponent<GeneSuicide>();
        geneSuicide.SetDuration(10.0f);
    }
}