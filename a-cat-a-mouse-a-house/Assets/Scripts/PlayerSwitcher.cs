using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public MonoBehaviour player1Controller;  // Assign Player 1's script
    public MonoBehaviour player2Controller;  // Assign Player 2's script

    private bool isPlayer1Active = true;

    void Start()
    {
        UpdatePlayerControl();
    }

    void Update()
    {
        UpdatePlayerControl();
        if (Input.GetKeyDown(KeyCode.K))
        {
            isPlayer1Active = !isPlayer1Active;
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

        string activePlayer = isPlayer1Active ? "Player 1" : "Player 2";
        Debug.Log($"Now controlling: {activePlayer}");
    }
}