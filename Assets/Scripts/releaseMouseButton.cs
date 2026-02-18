using UnityEngine;

public class releaseMouseButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TrapButton trapButton;
    private bool isCatNearby = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trapButton == null) return;
        if (Input.GetKeyDown(KeyCode.E) && isCatNearby) {
            trapButton.Release();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cat") {
            isCatNearby = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Cat") {
            isCatNearby = false;
        }
    }
}
