using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
