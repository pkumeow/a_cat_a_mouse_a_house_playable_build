using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private string targetPlayerName = "Cat";
    [SerializeField] private int requiredTuna = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == targetPlayerName)
        {
            CatStatus status = collision.gameObject.GetComponent<CatStatus>();

            if (status != null && status.tunaCount >= requiredTuna)
            {
                Break();
            }
            else
            {
                Debug.Log(requiredTuna - (status?.tunaCount ?? 0));
            }
        }
    }

    private void Break()
    {
        Debug.Log("Destroy!");
        Destroy(gameObject);
    }
}