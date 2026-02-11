using UnityEngine;
using Unity.Cinemachine;

public class PlayerSwitcher : MonoBehaviour
{
    public MonoBehaviour player1Controller;  // Assign Player 1's script
    public MonoBehaviour player2Controller;  // Assign Player 2's script

    public CinemachineCamera catCameraObject; // Assign the cat camera in the Inspector
    public CinemachineCamera mouseCameraObject; // Assign the mouse camera in the Inspector



    private bool isPlayer1Active = true;

    void Start()
    {
        UpdatePlayerControl();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            isPlayer1Active = !isPlayer1Active;
            UpdatePlayerControl();
        }
    }

    public bool GetIsPlayer1Active()
    {
        return isPlayer1Active;
    }

    void UpdatePlayerControl()
    {
        player1Controller.enabled = isPlayer1Active;
        player2Controller.enabled = !isPlayer1Active;

        // Switch camera priorities
        if (catCameraObject != null && mouseCameraObject != null)
        {
            Debug.Log("Camera objects found, attempting to switch...");
            
            // Directly set priority using CinemachineCamera type
            if (isPlayer1Active)
            {
                catCameraObject.Priority = 10;
                mouseCameraObject.Priority = 0;
                Debug.Log("Cat camera priority set to: 10, Mouse camera priority set to: 0");
            }
            else
            {
                catCameraObject.Priority = 0;
                mouseCameraObject.Priority = 10;
                Debug.Log("Cat camera priority set to: 0, Mouse camera priority set to: 10");
            }
        }
        else
        {
            Debug.LogWarning($"Camera objects missing! Cat: {catCameraObject != null}, Mouse: {mouseCameraObject != null}");
        }

        string activePlayer = isPlayer1Active ? "Player 1" : "Player 2";
        Debug.Log($"Now controlling: {activePlayer}");
    }
}