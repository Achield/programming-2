using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public float myTimer = 0f;    // Public time passed variable
    public float myFixedTimer = 0f;   // Public fixed update time
    public float spawnInterval = 0.5f;
    public float spawnTimer = 0f;
    public GameObject myEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myTimer += Time.deltaTime;      // Add time passed between frames

        spawnTimer += Time.deltaTime;       // Track enemy spawn time
        if (spawnTimer >= spawnInterval)     // Once the interval is hit, trigger an enemy spawn and reset timer
        {
            spawnTimer = 0f;
            Instantiate(myEnemy);
            Debug.Log("Enemy spawned");
        }
    }

    void FixedUpdate()
    {
        myFixedTimer += Time.fixedDeltaTime;     // Add time passed between each physics frame
    }
}
