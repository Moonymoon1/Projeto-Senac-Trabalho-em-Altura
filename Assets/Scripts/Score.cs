using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score;

    public void ScoreOnePoint()
    {
        score++;
        scoreText.text = $"{score}";
    }
}
