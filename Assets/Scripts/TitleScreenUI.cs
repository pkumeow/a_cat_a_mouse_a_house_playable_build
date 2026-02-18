using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleScreenUI : MonoBehaviour
{
    [Header("Title Text")]
    public TextMeshProUGUI titleLine1;
    public TextMeshProUGUI titleLine2;
    public TextMeshProUGUI titleLine3;

    [Header("Description / Flavour Text")]
    public TextMeshProUGUI miniDesc;

    void Start()
    {
        if (titleLine1 != null)
        {
            titleLine1.text = "A Cat,";
        }
        if (titleLine2 != null)
        {
            titleLine2.text = "A Mouse,";
        }
        if (titleLine3 != null)
        {
            titleLine3.text = "A House";
        }
        if (miniDesc != null)
        {
            miniDesc.text = "A game of unlikely companions.";
        }
    }
}
