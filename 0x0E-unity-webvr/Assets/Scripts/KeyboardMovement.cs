using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;

    // Update is called once per frame
    void Update()
    {
        // Get keyboard input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize(); // Normalize to prevent faster diagonal movement

        // Calculate movement amount and apply movement
        Vector3 movementAmount = movement * moveSpeed * Time.deltaTime;
        transform.Translate(movementAmount, Space.Self);

        // Calculate rotation amount and apply rotation
        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
