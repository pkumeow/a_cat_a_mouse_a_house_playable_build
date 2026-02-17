using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2f;
    public float turnSpeed = 200f;
    public float jumpForce = 2000f;

    Rigidbody rb;
    bool isGrounded = true;
    float horizontalInput, verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !rb.isKinematic)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 f = Camera.main.transform.forward; f.y = 0; f.Normalize();

        Vector3 move = f * verticalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        float yaw = horizontalInput * turnSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, yaw, 0f));
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Ground") || c.gameObject.CompareTag("Player"))
            isGrounded = true;
    }
}