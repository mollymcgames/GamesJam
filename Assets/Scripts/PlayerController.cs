using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintMultiplier = 2f; // Multiplier for sprint speed
    public float lookSpeed = 3f;
    public Transform cameraTransform; // Public transform reference to the camera

    private Rigidbody rb; // Rigidbody component
    private float rotationX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform; // Assign the main camera in Start to avoid repeated calls
        }
    }

    void Update()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        moveDirection = transform.TransformDirection(moveDirection); // Ensure the movement is in the direction the player faces

        // Check for sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection *= sprintMultiplier;
        }

        // Translate movement without affecting the y-axis by physics
        moveDirection.y = 0;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Player looking
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Rotate the entire player horizontally
        transform.Rotate(0, mouseX, 0, Space.World);

        // Rotate the player's camera vertically
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
