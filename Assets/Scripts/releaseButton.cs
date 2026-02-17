using UnityEngine;

public class releaseButton : MonoBehaviour
{
    public GateTrap gateTrap;

    private bool mouseNearby = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if  (gateTrap == null) return;
        if (Input.GetKeyDown(KeyCode.E) && gateTrap.IsClosed() && mouseNearby) {
            gateTrap.Open();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Mouse") {
            mouseNearby = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Mouse") {
            mouseNearby = false;
        }
    }
}
