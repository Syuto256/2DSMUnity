using UnityEngine;
using TMPro;

public class InGameScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // �V�[�����[�h���ɃX�R�A��0�Ƀ��Z�b�g
        ScoreManager.Instance.ResetScore();
        UpdateScoreUI();
    }

    void Update()
    {
        // ��ɃX�R�A���X�V
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