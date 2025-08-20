// Goal.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string nextSceneName = "Goal"; // ������"Goal"�V�[���ւ̑J�ڂɎg��

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.SaveHighScore();
            SceneManager.LoadScene(nextSceneName);
        }
    }
}