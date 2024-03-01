using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public Rigidbody objectRigidbody;
    public float throwForce = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Throw();
        }
    }

    void Throw()
    {
        objectRigidbody.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}
