using UnityEngine;
using TMPro;

public class GoalSceneManager : MonoBehaviour
{
    public TextMeshProUGUI goalScoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        // �Q�[���Ŋl�������X�R�A��\��
        DisplayGoalScore();
        // �X�R�A���n�C�X�R�A�Ɣ�r�E�ۑ�
        ScoreManager.Instance.SaveHighScore();
        // ���݂̃n�C�X�R�A��\��
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