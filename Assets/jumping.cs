using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping : MonoBehaviour
{
    private Rigidbody2D rb;

    public float jumpHeight = 9f;
    public bool canJump;

    public float coyoteTime = 0.5f;
    public float coyoteTimeCounter;

    public float jumpBufferTime = 0.2f;
    public float jumpBufferCounter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)       // If jump button (space) is pressed and
                                                                    // canJump bool is true (positive integer) then run code
        {
            rb.AddForce(Vector3.up * jumpHeight * 100);

            jumpBufferCounter = 0f;
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
    }
}
