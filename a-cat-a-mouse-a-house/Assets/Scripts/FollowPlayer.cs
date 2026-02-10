using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject[] players; // Assign Player 1 and Player 2 in Inspector
    public Vector3 offset = new Vector3(0, 3, -2);  // Adjusted for better view
    private PlayerSwitcher switcher;

    void Start()
    {
        // Find the switcher script in the scene
        players = GameObject.FindGameObjectsWithTag("Player");
        switcher = Object.FindFirstObjectByType<PlayerSwitcher>();
    }

    void LateUpdate()
    {
        if (switcher == null || players == null || players.Length < 2)
        {
            return;
        }

        // Check which player is currently active using the public function
        bool isP1 = switcher.GetIsPlayer1Active();

        GameObject activePlayer = isP1 ? players[0] : players[1];

        if (activePlayer != null)
        {
            // Smoothly or directly update camera position based on active player
            transform.position = activePlayer.transform.position + offset;

            // Optional: Make the camera always look at the player
            transform.LookAt(activePlayer.transform.position);
        }
    }
}