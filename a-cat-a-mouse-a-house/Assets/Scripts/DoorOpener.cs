using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject uiCanvas;
    public Transform doorPivot;
    public float openRotation = -90f;
    public float speed = 20f;

    private bool _isOpening = false;
    private Quaternion _targetRotation;
    public PickableItem keyScript;
    void Start()
    {
        if(keyScript == null)
        {
            keyScript = Object.FindFirstObjectByType<PickableItem>();
        }

        if (doorPivot == null)
        {
            doorPivot = transform.Find("DoorPivot");
        }

        if (doorPivot != null)
        {
            _targetRotation = doorPivot.localRotation * Quaternion.Euler(0, openRotation, 0);
        }

        if (uiCanvas != null)
        {
            uiCanvas.SetActive(false);
        }
    }

    void Update()
    {
        if (_isOpening && doorPivot != null)
        {
            doorPivot.localRotation = Quaternion.Slerp(
                doorPivot.localRotation,
                _targetRotation,
                Time.deltaTime * speed
            );

            if (Quaternion.Angle(doorPivot.localRotation, _targetRotation) < 0.1f)
            {
                doorPivot.localRotation = _targetRotation;
                _isOpening = false;
                ShowCompletionUI();
            }
        }
    }

    private void ShowCompletionUI()
    {
        if (uiCanvas != null)
        {
            uiCanvas.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cat")
        {
            if (CheckPlayerKey())
            {
                _isOpening = true;
            }
        }
    }

    private bool CheckPlayerKey()
    {
        return keyScript.GetKeyIsCarried();
    }
}