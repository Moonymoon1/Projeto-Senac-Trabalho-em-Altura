using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ScoreOnePoint()
    {
        score++;
        scoreText.text = $"{score}";
    }
}
