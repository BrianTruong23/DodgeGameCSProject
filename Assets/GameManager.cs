using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    SafeAreaController safeArea;

    void Awake()
    {
        safeArea = FindFirstObjectByType<SafeAreaController>();
    }

    void Start()
    {
        ResetGameState();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverText.gameObject.SetActive(true);
    }

    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();

        if (Time.timeScale == 0f && Keyboard.current.spaceKey.isPressed)
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        ResetGameState();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    void ResetGameState()
    {
        Time.timeScale = 1f;
        score = 0f;

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }

        if (safeArea != null)
        {
            safeArea.ResetArea();
        }
    }
}
