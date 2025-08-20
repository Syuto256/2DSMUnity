using UnityEngine;
using TMPro;

public class TitleSceneManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        DisplayHighScore();
    }

    private void DisplayHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + savedHighScore.ToString();
        }
    }
}