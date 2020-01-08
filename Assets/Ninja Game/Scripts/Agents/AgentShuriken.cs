using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentShuriken : MonoBehaviour {

    GameObject goSprite;
    SpriteRenderer spriteRenderer;

    GeneRotate geneRotate;
    GeneTranslate geneTranslate;
    GeneSuicide geneSuicide;

    void Awake() {
        goSprite = transform.Find("Sprite").gameObject;
        spriteRenderer = goSprite.GetComponent<SpriteRenderer>();
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

    void OnTriggerEnter2D(Collider2D other) {
        Toolbox.Log("OnTriggerEnter2D");
        if (other.tag == "Flesh") {
            ShurikenHitSFX();

            Destroy(geneRotate);
            Destroy(geneTranslate);
            Destroy(geneSuicide);

            transform.parent = other.transform;

            SpriteRenderer otherSpriteRenderer = other.GetComponent<SpriteRenderer>();
            if(otherSpriteRenderer != null) {
                spriteRenderer.sortingOrder = otherSpriteRenderer.sortingOrder;
            }
        }
    }

    void ShurikenHitSFX() {
        ActorSFXManager.I.Play(1);
    }
}
