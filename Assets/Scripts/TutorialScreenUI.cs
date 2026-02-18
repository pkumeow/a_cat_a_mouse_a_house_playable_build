using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialScreenUI : MonoBehaviour
{
    [Header("Header")]
    public TextMeshProUGUI headerText;

    [Header("Control Row Labels - Key Column")]
    public TextMeshProUGUI[] keyLabels;

    [Header("Control Row Labels - Action Column")]
    public TextMeshProUGUI[] actionLabels;

    private readonly string[] keys = new string[]
    {
        "WASD / Arrow Keys",
        "K",
        "Left Click",
        "F",
        "T",
        "Q"
    };

    private readonly string[] actions = new string[]
    {
        "Move character",
        "Switch between Cat and Mouse",
        "Pick up item",
        "Drop item",
        "Toggle display of controls",
        "Open / close quest list"
    };

    void Start()
    {
        if (headerText != null)
        {
            headerText.text = "Controls";
        }
        for (int i = 0; i < keys.Length; i++)
        {
            if (keyLabels != null && i < keyLabels.Length && keyLabels[i] != null)
            {
                keyLabels[i].text = keys[i];
            }
            if (actionLabels != null && i < actionLabels.Length && actionLabels[i] != null)
            {
                actionLabels[i].text = actions[i];
            }
        }
    }
}
