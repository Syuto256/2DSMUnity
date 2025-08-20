using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;

    // UIオブジェクトはシーンが変わるたびに参照を再取得
    private TextMeshProUGUI gameScoreText;
    private TextMeshProUGUI highScoreText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // シーンロード時のイベントを登録
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // シーンが変わるたびにUIの参照を更新する
        gameScoreText = GameObject.FindWithTag("GameScoreText")?.GetComponent<TextMeshProUGUI>();
        highScoreText = GameObject.FindWithTag("HighScoreText")?.GetComponent<TextMeshProUGUI>();

        if (scene.name == "Game")
        {
            ResetScore();
            UpdateGameScoreUI();
        }
        else if (scene.name == "Title")
        {
            DisplayHighScore();
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateGameScoreUI();
    }

    public void SaveHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    private void UpdateGameScoreUI()
    {
        if (gameScoreText != null)
        {
            gameScoreText.text = "Score:" + score.ToString();
        }
    }

    private void DisplayHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = "High Score:" + savedHighScore.ToString();
        }
    }
}