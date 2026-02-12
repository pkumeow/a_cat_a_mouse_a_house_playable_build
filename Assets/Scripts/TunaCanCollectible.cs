using UnityEngine;

public class TunaCanCollectible : MonoBehaviour
{
    [SerializeField] private float scaleMultiplier = 1.1f;
    [SerializeField] private string targetPlayerName = "Cat";

    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float floatAmplitude = 0.01f;
    [SerializeField] private float floatFrequency = 5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == targetPlayerName)
        {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        player.transform.localScale *= scaleMultiplier;

        CatStatus status = player.GetComponent<CatStatus>();
        if (status != null)
        {
            status.AddTuna();
        }

        Debug.Log(player.name + "+1 tuna can");

        Destroy(gameObject);
    }
}