using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputHandler : MonoBehaviour
{
    void Update()
    {
        // Check if there are any touches
        if (Input.touchCount > 0)
        {
            // Loop through all the touches
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                // Check the phase of the touch
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        // Handle touch began
                        HandleTouchBegan(touch.position);
                        break;
                    case TouchPhase.Moved:
                        // Handle touch moved
                        HandleTouchMoved(touch.position);
                        break;
                    case TouchPhase.Ended:
                        // Handle touch ended
                        HandleTouchEnded(touch.position);
                        break;
                }
            }
        }
    }

    // Method to handle touch began
    void HandleTouchBegan(Vector2 position)
    {
        Debug.Log("Touch began at position: " + position);
        // Add your logic for touch began
    }

    // Method to handle touch moved
    void HandleTouchMoved(Vector2 position)
    {
        Debug.Log("Touch moved to position: " + position);
        // Add your logic for touch moved
    }

    // Method to handle touch ended
    void HandleTouchEnded(Vector2 position)
    {
        Debug.Log("Touch ended at position: " + position);
        // Add your logic for touch ended
    }
}
