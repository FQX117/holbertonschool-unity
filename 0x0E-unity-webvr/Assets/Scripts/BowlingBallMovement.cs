using UnityEngine;

public class BowlingBallMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject gamealley;
    private float maxLeftPosition;
    private float maxRightPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the maximum left and right positions based on the width of the alley
        float alleyWidth = gamealley.transform.localScale.x;
        maxLeftPosition = gamealley.transform.position.x - alleyWidth / 2f;
        maxRightPosition = gamealley.transform.position.x + alleyWidth / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for left/right movement
        float movementInput = Input.GetAxis("Horizontal");

        // Calculate movement amount
        float movementAmount = movementInput * moveSpeed * Time.deltaTime;

        // Calculate new position
        Vector3 newPosition = transform.position + new Vector3(movementAmount, 0f, 0f);

        // Clamp the new position within the bowling alley
        newPosition.x = Mathf.Clamp(newPosition.x, maxLeftPosition, maxRightPosition);

        // Apply the new position
        //transform.position = newPosition;
    }
}

public class Ball : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize(); // Normalize to prevent faster diagonal movement

        // Apply movement
        Vector3 movementAmount = movement * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movementAmount);
    }
}
