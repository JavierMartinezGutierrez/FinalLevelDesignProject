using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character;
        private Transform m_Cam;
        private Vector3 m_Move;
        private bool m_Jump;
        private bool m_Catch;
        private bool m_Throw;

        [SerializeField] private int playerNumber = 1; // Define player number for this controller

        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            }

            // get the third person character (this should never be null due to require component)
            m_Character = GetComponent<ThirdPersonCharacter>();
        }

        private void Update()
        {
            if (!m_Jump)
            {
                // Detect jump input for the corresponding player
                if (CrossPlatformInputManager.GetButtonDown("Jump" + playerNumber))
                {
                    m_Jump = true;
                }
            }

            if (!m_Catch)
            {
                // Detect catch input for the corresponding player
                if (CrossPlatformInputManager.GetButtonDown("Catch" + playerNumber))
                {
                    m_Catch = true;
                }
            }

            if (!m_Throw)
            {
                // Detect throw input for the corresponding player
                if (CrossPlatformInputManager.GetButtonDown("Throw" + playerNumber))
                {
                    m_Throw = true;
                }
            }
        }

        private void FixedUpdate()
        {
            // Read input for movement for the corresponding player
            float h = CrossPlatformInputManager.GetAxis("Horizontal" + playerNumber);
            float v = CrossPlatformInputManager.GetAxis("Vertical" + playerNumber);

            // Calculate move direction to pass to character
            if (m_Cam != null)
            {
                // Calculate camera relative direction to move
                Vector3 camForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * camForward + h * m_Cam.right;
            }
            else
            {
                // Use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }

            // Pass parameters to the character control script
            m_Character.Move(m_Move, false, m_Jump);

            // Handle catch and throw actions
            if (m_Catch)
            {
                // Logic to try catching the ball
                TryCatchBall();
                m_Catch = false; // Reset catch flag
            }

            if (m_Throw)
            {
                // Logic to throw the ball
                ThrowBall();
                m_Throw = false; // Reset throw flag
            }

            m_Jump = false; // Reset jump flag
        }

    
    private void TryCatchBall()
        {
            // Logic to detect nearby ball and attempt to catch it
            // You can implement your own logic here
        }

        private void ThrowBall()
        {
            // Logic to throw the ball
            // You can implement your own logic here
        }
    }
}
