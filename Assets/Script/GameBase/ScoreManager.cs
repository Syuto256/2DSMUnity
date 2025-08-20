using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ゲーム開始時にスコアをリセット
    public void ResetScore()
    {
        score = 0;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    // ハイスコアを保存
    public void SaveHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            Debug.Log("ハイスコアを更新しました: " + score);
        }
    }
}