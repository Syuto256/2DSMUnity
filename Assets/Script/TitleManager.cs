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


}
