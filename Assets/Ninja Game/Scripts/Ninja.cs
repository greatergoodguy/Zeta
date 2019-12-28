using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    public static Ninja I;

    public float speed = 5.0f;
    public float jumpForce = 500;

    bool canJump = true;

    void Awake()
    {
        I = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            // Face Left
            transform.localScale = new Vector3(-1, 1, 1);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Face Right
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Move Left
            transform.position += Vector3.left * Time.deltaTime * speed;

        }
        if (Input.GetKey(KeyCode.D))
        {
            // Move Right
            transform.position += Vector3.right * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jump();
        }
    }

    void jump()
    {
        if (canJump)
        {
            canJump = false;
            GetComponent<Rigidbody2D>().AddForce(this.gameObject.transform.up * jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collidingObject)
    {
        canJump = true;
    }

}
