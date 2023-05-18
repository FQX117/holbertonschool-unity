using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class BowlingBallInteraction : MonoBehaviour
{
    private Rigidbody currentlyGrabbedBall;
    private bool isGrabbing;

    [SerializeField] private XRDirectInteractor interactor;

    // Update is called once per frame
    void Update()
    {
        if (isGrabbing)
        {
            // Get the position of the controller or mouse cursor
            Vector3 inputPosition = GetInputPosition();

            if (currentlyGrabbedBall != null)
            {
                // Move the grabbed ball to the input position
                currentlyGrabbedBall.MovePosition(inputPosition);
            }
        }
    }

    public void OnGrab(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Check if the grab button is pressed
            isGrabbing = true;

            // Cast a ray to check if it hits a bowling ball
            RaycastHit hit;
            if (Physics.Raycast(GetInputRay(), out hit))
            {
                Rigidbody ballRigidbody = hit.collider.GetComponent<Rigidbody>();
                if (ballRigidbody != null)
                {
                    // Set the currently grabbed ball
                    currentlyGrabbedBall = ballRigidbody;
                }
            }
        }
        else if (context.canceled)
        {
            // Release the grabbed ball
            isGrabbing = false;
            currentlyGrabbedBall = null;
        }
    }

    private Vector3 GetInputPosition()
    {
        // Use Input System to get the input position based on the input type
        if (Mouse.current != null)
        {
            // If using keyboard/mouse, get the mouse cursor position
            return Mouse.current.position.ReadValue();
        }
        else if (interactor != null)
        {
            // If using VR, get the position of the controller
            return interactor.transform.position;
        }

        // Return default position if no input type is detected
        return Vector3.zero;
    }

    private Ray GetInputRay()
    {
        // Use Input System to get the input ray based on the input type
        if (Mouse.current != null)
        {
            // If using keyboard/mouse, cast a ray from the camera to the mouse cursor position
            Camera mainCamera = Camera.main;
            return mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        }
        else if (interactor != null)
        {
            // If using VR, cast a ray from the controller
            return new Ray(interactor.transform.position, interactor.transform.forward);
        }

        // Return default ray if no input type is detected
        return new Ray();
    }
}