using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText, highScoreText;
    public int score, highScore;

    void Update()
    {
        SetHighScore();
    }

    public void ScoreOnePoint()
    {
        score++;
        scoreText.text = $"{score}";
    }

    private void SetHighScore()
    {
        if (score > highScore) highScore = score;
        highScoreText.text = $"highscore: {highScore}";
    }
}
