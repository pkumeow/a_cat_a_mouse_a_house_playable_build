using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 20.0f;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        // Initialization if needed
    }

    void Update()
    {
        // 1. Get input from WASD or Arrow Keys
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // 2. Handle Rotation FIRST (Make the player face the cursor)
        // We do this first so the movement knows which way is "forward"
        LookAtCursor();

        // 3. Handle Movement based on where the player is looking
        // verticalInput (W/S) moves the player along their local forward axis
        // horizontalInput (A/D) moves the player along their local right axis (strafing)
        Vector3 moveDirection = (transform.forward * verticalInput) + (transform.right * horizontalInput);

        // Apply movement using the direction relative to the player's facing
        transform.position += moveDirection * Time.deltaTime * speed;
    }

    void LookAtCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 lookPoint = ray.GetPoint(rayDistance);
            Vector3 direction = lookPoint - transform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}