using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan : MonoBehaviour {

    public GameObject target;        //Public variable to store a reference to the player game object

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start() {
        if (target == null && Ninja.I != null) {
            target = Ninja.I.gameObject;
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

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        Vector3 newPosition = new Vector3((target.transform.position + offset).x, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
