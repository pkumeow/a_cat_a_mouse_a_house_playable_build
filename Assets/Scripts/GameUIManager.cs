using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [Header("Player Controllers to disable on title screen")]
    public Player player1Controller;
    public Player player2Controller;

    [Header("Screens")]
    public GameObject titleScreen;
    public GameObject tutorialScreen;
    public GameObject achievementsScreen;
    public GameObject toDoPanel;

    [Header("Title Screen Buttons")]
    public Button playButton;
    public Button tutorialButton;
    public Button achievementsButton;

    [Header("Back Buttons")]
    public Button tutorialBackButton;
    public Button achievementsBackButton;

    private bool inGame = false;
    private bool toDoOpen = false;
    private bool tutorialOpen = false;

    void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayClicked);
        }
        if (tutorialButton != null)
        {
            tutorialButton.onClick.AddListener(OnTutorialClicked);
        }
        if (achievementsButton != null)
        {
            achievementsButton.onClick.AddListener(OnAchievementsClicked);
        }
        if (tutorialBackButton != null)
        {
            tutorialBackButton.onClick.AddListener(OnBackClicked);
        }
        if (achievementsBackButton != null)
        {
            achievementsBackButton.onClick.AddListener(OnBackClicked);
        }
        ShowTitleScreen();
    }

    void Update()
    {
        // Key controls only work after the player has pressed Play
        if (!inGame)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleTutorial();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleToDo();
        }
    }

    // Show title screen and hide everything else
    void ShowTitleScreen()
    {
        inGame = false;
        if (player1Controller != null)
        {
            player1Controller.enabled = false; // Disable player movement while in title screen
        }
        if (player2Controller != null)
        {
            player2Controller.enabled = false; // Disable player movement while in title screen
        }
        SetScreenVisibility(showTitle: true, showTutorial: false,
                            showAchievements: false, showToDo: false);
    }

    void OnPlayClicked()
    {
        inGame = true;
        toDoOpen = false;
        tutorialOpen = false;
        if (player1Controller != null)
        {
            player1Controller.enabled = true;
        }
        SetScreenVisibility(showTitle: false, showTutorial: false,
                            showAchievements: false, showToDo: false);
    }

    void OnTutorialClicked()
    {
        SetScreenVisibility(showTitle: false, showTutorial: true,
                            showAchievements: false, showToDo: false);
    }

    void OnAchievementsClicked()
    {
        SetScreenVisibility(showTitle: false, showTutorial: false,
                            showAchievements: true, showToDo: false);
    }

    void OnBackClicked()
    {
        if (inGame)
        {
            tutorialOpen = false;
            SetScreenVisibility(showTitle: false, showTutorial: false,
                                showAchievements: false, showToDo: toDoOpen);
        }
        else
        {
            ShowTitleScreen();
        }
    }

    void ToggleTutorial()
    {
        tutorialOpen = !tutorialOpen;
        SetScreenVisibility(showTitle: false, showTutorial: tutorialOpen,
                            showAchievements: false, showToDo: false);
    }

    void ToggleToDo()
    {
        toDoOpen = !toDoOpen;
        SetScreenVisibility(showTitle: false, showTutorial: false,
                            showAchievements: false, showToDo: toDoOpen);
    }

    void SetScreenVisibility(bool showTitle, bool showTutorial,
                              bool showAchievements, bool showToDo)
    {
        if (titleScreen != null)
        {
            titleScreen.SetActive(showTitle);
        }
        if (tutorialScreen != null)
        {
            tutorialScreen.SetActive(showTutorial);
        }
        if (achievementsScreen != null)
        {
            achievementsScreen.SetActive(showAchievements);
        }
        if (toDoPanel != null)
        {
            toDoPanel.SetActive(showToDo);
        }
    }
}
