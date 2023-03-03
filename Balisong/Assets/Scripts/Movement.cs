using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public float horizontal;
    public float movespeed;
    public float jumpforce;
    //private bool isFacingRight = true;

    // Update is called once per frame.
    void Update()
    {
        //Horizontal movement.
        horizontal = Input.GetAxisRaw("Horizontal") * movespeed * Time.deltaTime;

        //Allows the player to jump if press space.
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpforce);
        }

        //Allows the player to jump higher by holdung down "Jump" Key.
        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
        }

    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontal * movespeed, rb2d.velocity.y);
    }

    //Creates a circle below the player that checks if the player is grounded to jump
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
