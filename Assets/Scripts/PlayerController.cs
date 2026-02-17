using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 20.0f;
    private float horizontalInput;
    private float verticalInput;
    private bool isMouseTrapped = false;

    void Start()
    {
        // Initialization if needed
    }

    void Update()
    {
        // chech if the mouse is trapped
        if (isMouseTrapped) {
            return;
        }
        // 1. Get input from WASD or Arrow Keys
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // 2. Handle Rotation FIRST (Make the player face the cursor)
        // We do this first so the movement knows which way is "forward"
        // LookAtCursor();

        // Get Camera directions:
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0; // Flatten the forward vector to the horizontal plane
        cameraRight.y = 0;   // Flatten the right vector to the horizontal plane
        cameraForward.Normalize();
        cameraRight.Normalize();

        // 3. Handle Movement based on where the player is looking
        // verticalInput (W/S) moves the player along their local forward axis
        // horizontalInput (A/D) moves the player along their local right axis (strafing)
        // Vector3 moveDirection = (transform.forward * verticalInput) + (transform.right * horizontalInput);
        // Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        Vector3 moveDirection = (cameraForward * verticalInput) + (cameraRight * horizontalInput);

        if (moveDirection.magnitude > 0.1f)
        {
            
            // Apply movement using the direction relative to the player's facing
            transform.position += moveDirection * Time.deltaTime * speed;

            // rotate to the direction of movement
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1);
        }

    }

    // This is the original code
    // void LookAtCursor()
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     Plane groundPlane = new Plane(Vector3.up, transform.position);
    //     float rayDistance;

    //     if (groundPlane.Raycast(ray, out rayDistance))
    //     {
    //         Vector3 lookPoint = ray.GetPoint(rayDistance);
    //         Vector3 direction = lookPoint - transform.position;
    //         direction.y = 0;

    //         if (direction != Vector3.zero)
    //         {
    //             transform.rotation = Quaternion.LookRotation(direction);
    //         }
    //     }
    // }


    // freeze the player movement
    public void FreezeMovement()
    {
        isMouseTrapped = true;
    }
    public void UnfreezeMovement()
    {
        isMouseTrapped = false;
    }
}