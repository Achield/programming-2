using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{

    public float accel = 10f;   // A public variable to multiply direction speed by, and can be controlled in the editor because public
    public float horAccel = 2.5f;
    public float vertAccel = 2.5f;
    private Rigidbody2D rb;

    public float jumpHeight = 10f;
    public bool canJump;

    public float coyoteTime = 0.1f;
    public float coyoteTimeCounter;

    public float jumpBufferTime = 0.2f;
    public float jumpBufferCounter;

    public float collectedScore = 0f;

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

    // FixedUpdate is called every physics update
    // It is a void function so it does not return any data
    void FixedUpdate()
    {
        Vector3 currentDir = Dir();  // Calls the Dir() function to find out what the current player inputs are
                                     // Throw it into Translate, multiplied by the acceleration variable
        currentDir.x *= horAccel * 0.05f;
        currentDir.y *= vertAccel * 0.05f;

        transform.Translate(currentDir);     //main move script for the player based on the x and y inputs (can use rb.Addforce(currentDir); instead

         canJump = Physics2D.CircleCast(transform.position, 0.5f, Vector2.down, 0.05f);

        // Another alternative is rb.velocity = new Vector2(x * speed, rb.velocity.y)
    }

    // Gets the inputs of the WASD/keyboard/controller
    // This function gets the overall direction and returns it as a vector3
    public Vector3 Dir()
    {
        float y = Input.GetAxis("Vertical");     // Uses Unity's default vertical axis inputs (W and S or arrow keys up and down) to get a value between -1 to 1
        float x = Input.GetAxis("Horizontal");   // Uses Unity's default horizontal axis inputs (A and S or arrow keys left and right) to get a value between -1 to 1

        Vector3 myDir = new Vector3(x, 0, 0);   // Constructs the vector based off the vertical and horizontal axis inputs
        return myDir;     // Returns that value
    }

    public void OnTriggerEnter2D(Collider2D collision)      // Checking for enemy or collectible collisions
    {
        Debug.Log("Player has collided with " + collision.gameObject.name);

        if (collision.gameObject.tag == "Collectible")   // When we collide with something with the tag collectible, destroy it and increase player score
        {
            Destroy(collision.gameObject);    // Destroys the collectible gameobject
            collectedScore++;    // Adds +1 to collectedScore on every collision
        }
    }

    //public void OnCollisionExit2D(Collision2D collision)
    //{
    //    Debug.Log("Exited collision");
    //    StartCoroutine(CoyoteJump(coyoteTime));
    //}

    //public IEnumerator CoyoteJump(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    canJump = false;
    //}

}