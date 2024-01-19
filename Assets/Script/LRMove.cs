using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRMove : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    private Animator animator;

    void Update()
    {
        // Get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement vector
        Vector2 movement = new Vector2(horizontalInput, 0f) * speed * Time.deltaTime;

        // Move the player
        transform.Translate(movement);

        if (movement.x > 0)
        {
            sr.flipX = true;
        }
        else if (movement.x < 0)
        {
            sr.flipX = false;
        }
        //animator.SetBool("IsWalking", true);
    }
}

