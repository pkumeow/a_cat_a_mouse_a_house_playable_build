using UnityEngine;
using Unity.Cinemachine;

public class PlayerSwitcher : MonoBehaviour
{
    public MonoBehaviour player1Controller;
    public MonoBehaviour player2Controller;

    public CinemachineCamera catCameraObject;
    public CinemachineCamera mouseCameraObject;

    public Carrier catCarrier; // ✅ 拖 Cat 身上的 Carrier

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

            // ✅ 切到鼠（player2）时：立刻放下
            if (!isPlayer1Active && catCarrier != null)
                catCarrier.Drop();

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

        if (catCameraObject != null && mouseCameraObject != null)
        {
            catCameraObject.Priority = isPlayer1Active ? 10 : 0;
            mouseCameraObject.Priority = isPlayer1Active ? 0 : 10;
        }

        // ✅ 只有控制猫时才允许自动捡鼠
        if (catCarrier != null)
            catCarrier.allowAutoPickup = isPlayer1Active;
    }
}