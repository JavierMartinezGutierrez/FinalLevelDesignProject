using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPickUp : MonoBehaviour
{
    public GameObject Ball1, Ball2, Ball3;
    
    public bool interactable, pickedup;
    public Rigidbody objRigidbody;
    public float throwAmount;

   
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
               
                objRigidbody.useGravity = false;
                pickedup = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                
                objRigidbody.useGravity = true;
                pickedup = false;
            }
            if (pickedup == true)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    objRigidbody.useGravity = true;
                    
                    pickedup = false;
                }
            }
        }
    }
}
