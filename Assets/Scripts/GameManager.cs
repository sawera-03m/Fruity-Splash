using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int lives = 3;

    // FIX: UI references add ki gayi hain
    public Text scoreText;
    public Text livesText;
    public GameObject gameOverPanel;

    // FIX: game over sound (assign Assets/Sounds/GameOver.wav in Inspector)
    public AudioClip gameOverSound;
    AudioSource audioSource;

    bool isGameOver = false;

    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        Time.timeScale = 1f;
        UpdateUI();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    // FIX: Score add karne ka function
    public void AddScore(int amount)
    {
        if (isGameOver) return;
        score += amount;
        UpdateUI();
    }

    // FIX: Life lose karne ka function
    public void LoseLife()
    {
        if (isGameOver) return;
        lives--;
        UpdateUI();

        if (lives <= 0)
            GameOver();
    }

    // FIX: Game over logic
    void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;

        // FIX: game over sound bajta hai
        if (audioSource != null && gameOverSound != null)
            audioSource.PlayOneShot(gameOverSound);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    // FIX: UI update karna
    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
