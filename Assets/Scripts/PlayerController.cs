using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    public float turnSpeed = 200.0f;
    public float jumpForce = 1.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent physics from tipping the player over
    }

    void Update()
    {
        // 1. Get input from WASD or Arrow Keys
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Get Camera directions:
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0; // Flatten the forward vector to the horizontal plane
        cameraRight.y = 0;   // Flatten the right vector to the horizontal plane
        cameraForward.Normalize();
        cameraRight.Normalize();

        // 3. Handle Movement based on where the player is looking
        // verticalInput (W/S) moves the player along their local forward axis
        transform.position += cameraForward * verticalInput * Time.deltaTime * speed;

        // horizontalInput (A/D) moves the player along their local right axis (strafing)
        transform.Rotate(0, horizontalInput * turnSpeed * Time.deltaTime, 0); // pitch, yaw (we are rotating on yaw), roll

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            isGrounded = true;
        }
    }
}