using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    Score score;
    void Start()
    {
        score = GameObject.Find("ScoreManager").GetComponent<Score>();
        score.highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
        PlayerPrefs.SetInt("highScore", score.highScore);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        Debug.Log("ablubble");
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

