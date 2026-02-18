using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToDoPanel : MonoBehaviour
{
    [Header("Header")]
    public TextMeshProUGUI headerText;

    [Header("Task Labels")]
    public TextMeshProUGUI[] taskLabels;

    // Three temp in-game objectives for now
    private readonly string[] taskNames = new string[]
    {
        "Find the key hidden in the house.",
        "Press the pressure plate to clear the path.",
        "Reach the front door as the Cat."
    };

    private bool[] completed;

    void Awake()
    {
        completed = new bool[taskNames.Length];
    }

    void Start()
    {
        if (headerText != null)
        {
            headerText.text = "To-Do";
        }
        RefreshLabels();
    }

    // For task condition logic later
    public void CompleteTask(int index)
    {
        if (index < 0 || index >= completed.Length)
        {
            return;
        }
        completed[index] = true;
        RefreshLabels();
    }

    void RefreshLabels()
    {
        for (int i = 0; i < taskNames.Length; i++)
        {
            if (taskLabels == null || i >= taskLabels.Length || taskLabels[i] == null)
            {
                continue;
            }
            if (completed[i])
            {
                taskLabels[i].text = "✓  " + taskNames[i];
                taskLabels[i].color = new Color(0.5f, 0.5f, 0.5f);
            }
            else
            {
                taskLabels[i].text = "•  " + taskNames[i];
                taskLabels[i].color = Color.white;
            }
        }
    }
}
