using UnityEngine;

public class GateTrap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject gate;
    public float dropSpeed = 5f;
    public float minY = 0.25f;

    public string trapCharacter = "Cat";
    public string openCharacter = "Mouse";

    private bool isClosed = false;
    private Vector3 originalPosition;
    private Vector3 droppedPosition;


    void Start()
    {
        // store the original position of the gate
        originalPosition = gate.transform.position;

        // get the position of the gate after it is dropped
        droppedPosition = new Vector3(originalPosition.x, minY, originalPosition.z);
    }

    void Update()
    {
        if (isClosed && gate != null)
        {
            // move the gate to the correct position
            gate.transform.position = Vector3.MoveTowards(gate.transform.position, droppedPosition, dropSpeed * Time.deltaTime);
        } else if (!isClosed && gate != null) {
            // move the gate to the original position
            gate.transform.position = Vector3.MoveTowards(gate.transform.position, originalPosition, dropSpeed * Time.deltaTime);
        }


    }
    public void Open()
    {
        isClosed = false;
    }
    public void Close()
    {
        isClosed = true;
    }

    public bool IsClosed()
    {
        return isClosed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isClosed && other.gameObject.name == trapCharacter)
        {
            Close();
        } else if (isClosed && other.gameObject.name == openCharacter) {
            Open();
        }
    }
}
