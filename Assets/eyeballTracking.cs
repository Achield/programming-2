using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeballTracking : MonoBehaviour
{

    GameObject myTarget;

    // Start is called before the first frame update
    void Start()
    {
        myTarget = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Calculating the distance between the object and the player (this is in world space)
        Vector3 delta = myTarget.transform.position - transform.position;

        // Debug checking the distance from eyeball to player
        Debug.DrawRay(transform.position, delta, Color.yellow);

        // Define localUp and localForward
        Vector3 localUp = transform.TransformDirection(Vector3.up);
        Vector3 localForward = transform.TransformDirection(Vector3.forward);

        // Debug showing the up vector of the eyeball (this line needs fixing)
        Debug.DrawRay(transform.position, localUp, Color.cyan);
        Debug.DrawRay(transform.position, localForward, Color.red);

        // angleDelta find the angle between two vectors in this case
        // The local up of the eyeball (pupil) and the vector from player to eyeball
        float angleDelta = Vector3.Angle(delta, localUp);
        Debug.Log("current angle: " + angleDelta);

        // Rotate by the difference
        if (angleDelta > 0.5)
        {
            transform.Rotate(Vector3.forward, angleDelta);
        }
    }
}
