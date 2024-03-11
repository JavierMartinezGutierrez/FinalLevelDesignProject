using System;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour

{
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(3f, 0f, 0f); // Adjust the velocity as needed

    }

    void Update()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(3f, 0f, 0f)); // Adjust the force as needed
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision events here
    }

    internal bool IsHeld()
    {
        throw new NotImplementedException();
    }

    // Add other methods or variables as needed
}