using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    Score score;
    AudioSource audioSource;
    [SerializeField] AudioClip gameOverSound;
    [SerializeField] AudioClip buttonClickSound;
    void Start()
    {
        score = GameObject.Find("ScoreManager").GetComponent<Score>();
        score.highScore = PlayerPrefs.GetInt("highScore", 0);
        audioSource = GetComponent<AudioSource>();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
        PlayerPrefs.SetInt("highScore", score.highScore);
        PlaySound(gameOverSound);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        Debug.Log("ablubble");
        SceneManager.LoadScene(1);
        //PlaySound(buttonClickSound);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        //PlaySound(buttonClickSound);
    }

    public void PlaySound(AudioClip sonzinho)
    {
        audioSource.PlayOneShot(sonzinho);
    }
    
}

