using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherScript : MonoBehaviour
{
    public Ball ball; // Reference to the Ball script attached to the GameObject

    void Update()
    {
        // Example: Increase throw force when the player presses a key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball.throwForce += 5f; // Increase throw force by 5 units
        }
    }
}
