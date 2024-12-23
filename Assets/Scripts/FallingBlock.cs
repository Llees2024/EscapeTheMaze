using UnityEngine;
using TMPro;

public class FallingBlock : MonoBehaviour
{
    public TMP_Text gameOverText;
    private bool gameOver = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !gameOver)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over! Press R to Restart";
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        gameOverText.text = "";
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
