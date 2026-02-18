using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementsScreenUI : MonoBehaviour
{
    [Header("Header")]
    public TextMeshProUGUI headerText;

    [Header("Achievement Name Labels")]
    public TextMeshProUGUI[] nameLabels;

    [Header("Achievement Status Labels")]
    public TextMeshProUGUI[] statusLabels;

    [Header("Achievement Description Labels")]
    public TextMeshProUGUI[] descLabels;

    private readonly string[] names = new string[]
    {
        "First Steps",
        "Tag Team",
        "Housekeeper"
    };

    private readonly string[] descriptions = new string[]
    {
        "Pick up the key for the first time.",
        "Switch between the Cat and Mouse at least 5 times in one run.",
        "Open the front door and escape the house."
    };

    // All start locked. Flip to true as the player earns them.
    private readonly bool[] unlocked = new bool[]
    {
        false,
        false,
        false
    };

    void Start()
    {
        if (headerText != null)
        {
            headerText.text = "Achievements";
        }
        for (int i = 0; i < names.Length; i++)
        {
            if (nameLabels != null && i < nameLabels.Length && nameLabels[i] != null)
            {
                nameLabels[i].text = names[i];
            }
            if (descLabels != null && i < descLabels.Length && descLabels[i] != null)
            {
                descLabels[i].text = descriptions[i];
            }
            if (statusLabels != null && i < statusLabels.Length && statusLabels[i] != null)
            {
                if (unlocked[i])
                {
                    statusLabels[i].text = "✓  Unlocked";
                    statusLabels[i].color = new Color(0.2f, 0.8f, 0.2f); // Green
                }
                else
                {
                    statusLabels[i].text = "🔒  Locked";
                    statusLabels[i].color = new Color(0.6f, 0.6f, 0.6f); // Grey
                }
            }
        }
    }
}
