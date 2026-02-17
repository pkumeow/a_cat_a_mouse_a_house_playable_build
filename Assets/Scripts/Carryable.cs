using UnityEngine;

public class Carryable : MonoBehaviour
{
    public Rigidbody rb;
    public Collider col;
    public Behaviour mouseMove; 

    public bool IsCarried { get; private set; }

    void Reset()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        mouseMove = GetComponent<Behaviour>(); 
    }

    public void PickUp(Transform carryPoint, Collider catCol)
    {
        if (IsCarried) return;
        IsCarried = true;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        Physics.IgnoreCollision(col, catCol, true);

        if (mouseMove) mouseMove.enabled = false;

        // let mouse follow the carry point
        rb.transform.SetParent(carryPoint, false);
        rb.transform.localPosition = Vector3.zero;
        rb.transform.localRotation = Quaternion.identity;
    }

    public void Drop(Collider catCol)
    {
        if (!IsCarried) return;

        rb.transform.SetParent(null, true);

        // put down on top of the cat
        var cb = catCol.bounds;
        float mouseHalfH = col.bounds.extents.y;
        rb.position = new Vector3(cb.center.x, cb.max.y + mouseHalfH + 0.05f, cb.center.z);

        rb.isKinematic = false;
        Physics.IgnoreCollision(col, catCol, false);

        if (mouseMove) mouseMove.enabled = true;

        IsCarried = false;
    }
}