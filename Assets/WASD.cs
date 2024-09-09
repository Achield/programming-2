using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{

    public float accel = 10f;   // A public variable to multiply direction speed by, and can be controlled in the editor because public
    public float horAccel = 0.5f;
    public float vertAccel = 0.5f;

    public float collectedScore = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // FixedUpdate is called every physics update
    // It is a void function so it does not return any data
    void FixedUpdate()
    {
        Vector3 currentDir = Dir();  // Calls the Dir() function to find out what the current player inputs are
                                     // Throw it into Translate, multiplied by the acceleration variable
        currentDir.x *= horAccel;
        currentDir.y *= vertAccel;

        transform.Translate(currentDir);     //main move script for the player based on the x and y inputs
    }

    // Gets the inputs of the WASD/keyboard/controller
    // This function gets the overall direction and returns it as a vector3
    public Vector3 Dir()
    {
        float y = Input.GetAxis("Vertical");     // Uses Unity's default vertical axis inputs (W and S or arrow keys up and down) to get a value between -1 to 1
        float x = Input.GetAxis("Horizontal");   // Uses Unity's default horizontal axis inputs (A and S or arrow keys left and right) to get a value between -1 to 1

        Vector3 myDir = new Vector3(x, y, 0);   // Constructs the vector based off the vertical and horizontal axis inputs
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
}
