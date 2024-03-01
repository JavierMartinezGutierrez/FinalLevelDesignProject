using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchObject : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throwable"))
        {
            Destroy(collision.gameObject); // Destroy the thrown object
            // Add points to the player's score, or any other desired action
        }
    }
}
