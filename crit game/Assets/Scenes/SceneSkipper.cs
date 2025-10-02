using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSkipper : MonoBehaviour
{
    public void LoadGame()
    {
        //Possible coroutine with particle effects for polish
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        //Possible coroutine with particle effects for polish
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        //Possible coroutine with particle effects for polish
        SceneManager.LoadScene(0);
    }
}
