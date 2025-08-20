using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleManager : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ReturnTitle()
    {
        SceneManager.LoadScene("Title");
    }

    string nextSceneName = "GameOver";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }


}
