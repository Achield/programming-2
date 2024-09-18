using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public float myTimer = 0f;    // Public time passed variable
    public float myFixedTimer = 0f;   // Public fixed update time
    public float spawnInterval = 0.5f;
    public float spawnTimer = 0f;
    public GameObject myCollectible;
    public GameObject myPlayer;
    public TextMeshProUGUI myScore;
    float playerScore = 0f;
    WASD playerScript;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        playerScript = myPlayer.GetComponent<WASD>();
    }

    // Update is called once per frame
    void Update()
    {
        myTimer += Time.deltaTime;      // Add time passed between frames

        spawnTimer += Time.deltaTime;       // Track enemy spawn time
        if (spawnTimer >= spawnInterval)     // Once the interval is hit, trigger an enemy spawn and reset timer
        {
            spawnTimer = 0f;
            Instantiate(myCollectible);
            // Debug.Log("Collectible spawned");
        }
        // Because gameManager has an explicit connection to the player we can reference the player components including WASD.cs to find score
        playerScore = playerScript.collectedScore;
        myScore.text = playerScore.ToString();
    }

    void FixedUpdate()
    {
        myFixedTimer += Time.fixedDeltaTime;     // Add time passed between each physics frame
    }
}
