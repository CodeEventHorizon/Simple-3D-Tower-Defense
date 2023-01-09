using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void StartEasyRegular()
    {
        SceneManager.LoadScene(2); // Regular
    }
    public void StartEasyRegular2()
    {
        SceneManager.LoadScene(3); // Regular 2
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
