using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject splashPanel;
    public Button playButton;
    public Text titleText;
    public Text subtitleText;

    void Start()
    {
        // Make sure game objects are visible
        if (splashPanel != null)
            splashPanel.SetActive(true);
        if (playButton != null)
            playButton.onClick.AddListener(OnPlayClicked);
    }

    public void OnPlayClicked()
    {
        // Load the game scene (build index 1)
        SceneManager.LoadScene(1);
    }
}
