using UnityEngine;
using TMPro;

public class GoalSceneManager : MonoBehaviour
{
    public TextMeshProUGUI goalScoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        // ゲームで獲得したスコアを表示
        DisplayGoalScore();
        // スコアをハイスコアと比較・保存
        ScoreManager.Instance.SaveHighScore();
        // 現在のハイスコアを表示
        DisplayCurrentHighScore();
    }

    private void DisplayGoalScore()
    {
        if (goalScoreText != null && ScoreManager.Instance != null)
        {
            goalScoreText.text = "Your Score: " + ScoreManager.Instance.score.ToString();
        }
    }

    private void DisplayCurrentHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + savedHighScore.ToString();
        }
    }
}