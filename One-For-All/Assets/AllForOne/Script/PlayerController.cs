using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public bool isWalking = false;
    public Vector2 maxVelocity = new Vector2(3, 5);
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var forceX = 0f;
        var forceY = 0f;

        var absVelX = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);

        if(Input.GetKey("d")) {
            if(absVelX < maxVelocity.x)
                forceX = speed;
                animator.SetBool("isWalking", true);
                isWalking = true;

            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(Input.GetKey("a")) {
            if(absVelX < maxVelocity.x)
                forceX = -speed;
                animator.SetBool("isWalking", true);
                isWalking = true;

                transform.localScale = new Vector3(-1, 1, 1);
        }
        else {
            animator.SetBool("isWalking", false);
        }

        GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, forceY));
    }
}
