using UnityEngine;

public class TrapButton : MonoBehaviour
{
    public string trapCharacter = "Mouse";
    public GameObject trapButton;
    public GameObject releaseButton;

    private bool isTrapped = false;
    private Player trappedMouse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (releaseButton != null)
        {
            releaseButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trap(Player trappedMouse)
    {
        isTrapped = true;
        trappedMouse.FreezeMovement();
        if (releaseButton != null) {
            releaseButton.SetActive(true);
        }
    }

    public void Release()
    {
        isTrapped = false;
        if (trappedMouse != null) {
            trappedMouse.UnfreezeMovement();
        }
        if (releaseButton != null) {
            releaseButton.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isTrapped) return;
        if (other.gameObject.name != trapCharacter) return;
        trappedMouse = other.GetComponent<Player>();
        if (trappedMouse == null) {
            return;
        }
        Trap(trappedMouse);
    }


}
