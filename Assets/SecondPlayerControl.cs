using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class SecondPlayerControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;                   // The world-relative desired move direction, calculated from the camForward and user input.
        private bool m_Jump;                      // Whether or not the player should jump

        private void Start()
        {
            // Get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning("Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // We use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // Get the ThirdPersonCharacter (this should never be null due to require component)
            m_Character = GetComponent<ThirdPersonCharacter>();
        }

        private void Update()
        {
            if (!m_Jump)
            {
                // Check for jump input for Player 2
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump2");
            }
        }

        private void FixedUpdate()
        {
            // Read input for movement
            float h = CrossPlatformInputManager.GetAxis("Horizontal2");
            float v = CrossPlatformInputManager.GetAxis("Vertical2");

            // Calculate move direction to pass to character
            if (m_Cam != null)
            {
                // Calculate camera relative direction to move
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // Use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }

            // Pass parameters to the character control script
            m_Character.Move(m_Move, false, m_Jump);
            m_Jump = false; // Reset jump flag after jump
        }
    }
}