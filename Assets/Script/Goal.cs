using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    string nextSceneName = "Goal";

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

}
