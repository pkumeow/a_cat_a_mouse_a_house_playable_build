using UnityEngine;

public class Carrier : MonoBehaviour
{
    public Transform carryPoint;
    public Collider catCol;

    public float carryPointExtraHeight = 0.05f;
    public float attachEps = 0.02f;
    public KeyCode dropKey = KeyCode.Q;

    public bool allowAutoPickup = true;  //if false, the carrier will not automatically pick up objects on collision, but the player can still call PickUp manually

    Carryable carrying;

    void LateUpdate()
    {
        if (carryPoint && catCol)
        {
            var b = catCol.bounds;
            carryPoint.position = new Vector3(b.center.x, b.max.y + carryPointExtraHeight, b.center.z);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(dropKey))
            Drop();
    }

    void OnCollisionStay(Collision collision)
    {
        if (!allowAutoPickup) return;    //catch only if allowed
        if (carrying != null) return;

        var c = collision.collider.GetComponentInParent<Carryable>();
        if (c == null || c.IsCarried) return;

        if (c.col.bounds.min.y < catCol.bounds.max.y - attachEps) return;

        c.PickUp(carryPoint ? carryPoint : transform, catCol);
        carrying = c;
    }

    public void Drop()
    {
        if (carrying == null) return;
        carrying.Drop(catCol);
        carrying = null;
    }
}