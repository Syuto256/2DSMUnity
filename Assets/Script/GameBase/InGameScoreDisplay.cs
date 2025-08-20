using UnityEngine;
using TMPro;

public class InGameScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // シーンロード時にスコアを0にリセット
        ScoreManager.Instance.ResetScore();
        UpdateScoreUI();
    }

    void Update()
    {
        // 常にスコアを更新
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null && ScoreManager.Instance != null)
        {
            scoreText.text = "Score: " + ScoreManager.Instance.score.ToString();
        }
    }
}