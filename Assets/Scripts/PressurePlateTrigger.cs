using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    public GameObject targetObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("HIT PRESSURE");
            targetObject.SetActive(false);
        }
    }
}