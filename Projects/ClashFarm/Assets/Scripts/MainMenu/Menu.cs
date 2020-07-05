using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsynchronously(sceneIndex));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    
    IEnumerator LoadSceneAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            _slider.value = progress;

            yield return null;
        }
    }
}
