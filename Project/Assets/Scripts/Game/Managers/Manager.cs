using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static void LoadInfiniteMode()
    {
        GameManager.infiniteMode = true;
        LoadScene("Game");
    }

    public static void LoadRegularMode()
    {
        GameManager.infiniteMode = false;
        LoadScene("Game");
    }

    public static void LoadMenu() {
        LoadScene("Menu");
    }

    static void LoadScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public void SetInfiniteMode(bool isInInfiniteMode)
    {
        GameManager.SetTutorialMode(isInInfiniteMode);
        LoadScene("Game");
    }

    public void SetTutorialMode(bool isInTutorialMode)
    {
        GameManager.tutorialMode = isInTutorialMode;
        LoadScene("Game");
    }

    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
