using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan : MonoBehaviour {

    public static CameraMan I;

    public GameObject target;        //Public variable to store a reference to the player game object
    public GameObject leftBound;
    public GameObject rightBound;

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    private Ninja player;

    private void Awake() {
        I = this;
    }

    // Use this for initialization
    void Start() {
        player = Ninja.GetPlayer();
        if (target == null && player != null) {
            target = player.gameObject;
        }
        if (target == null) {
            return;
        }
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - target.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate() {
        if (target == null) {
            return;
        }

        float minPosX = leftBound != null ? leftBound.transform.position.x : -20f;
        float maxPosX = rightBound != null ? rightBound.transform.position.x : 250f; 
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        float newPosX = Mathf.Min(Mathf.Max((target.transform.position + offset).x, minPosX), maxPosX);
        Vector3 newPosition = new Vector3(newPosX, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
