// Goal.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string nextSceneName = "Goal"; // ‚±‚±‚Í"Goal"ƒV[ƒ“‚Ö‚Ì‘JˆÚ‚Ég‚¤

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.SaveHighScore();
            SceneManager.LoadScene(nextSceneName);
        }
    }
}