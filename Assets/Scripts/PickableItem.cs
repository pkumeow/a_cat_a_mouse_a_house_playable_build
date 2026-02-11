using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public float interactionDistance = 0.8f;
    public Transform holdPoint;

    // Assign your Player 1 and Player 2 GameObjects in the Inspector
    public GameObject player;

    private bool isCarried = false;
    private Rigidbody rb;
    private Collider col;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        holdPoint = player.transform.Find("HoldPoint");
    }

    void Update()
    {
        if (isCarried)
        {
            FollowPlayer();

            // Drop item with F key
            if (Input.GetKeyDown(KeyCode.F))
            {
                Drop();
            }
        }
        else
        {
            if (player.transform != null)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance <= interactionDistance && Input.GetMouseButtonDown(0))
                {
                    PickUp();
                }
            }
        }
    }

    void FollowPlayer()
    {
        if (holdPoint == null)
        {
            return;
        }

        transform.position = holdPoint.position;
        transform.rotation = holdPoint.rotation;
    }

    public bool GetKeyIsCarried()
    {
        return isCarried;
    }

    void PickUp()
    {
        if (holdPoint == null) return;

        isCarried = true;
        if (rb != null) rb.isKinematic = true;
        if (col != null) col.enabled = false;
    }

    void Drop()
    {
        isCarried = false;
        if (rb != null) rb.isKinematic = false;
        if (col != null) col.enabled = true;
    }
}