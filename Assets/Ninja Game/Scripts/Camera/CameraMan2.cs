using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan2 : MonoBehaviour {

    public static CameraMan2 I;

    public GameObject target;        //Public variable to store a reference to the player game object

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    public float speed = 0.1f;

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

    void FixedUpdate() {
        if (target == null) {
            return;
        }

        
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        float newPosX = (target.transform.position + offset).x;
        float newPosY = (target.transform.position + offset).y;
        // Vector3 newPosition = new Vector3(newPosX, newPosY, transform.position.z);


        Vector3 newTarget = new Vector3(newPosX, newPosY, transform.position.z);
        // var fromCameraToTarget = (newTarget - transform.position) * (speed * Time.deltaTime);
        // Vector3 newPosition = transform.position + fromCameraToTarget;

        Vector3 newPosition = Vector3.Lerp(transform.position, newTarget, speed);


        transform.position = newPosition;
    }
}
