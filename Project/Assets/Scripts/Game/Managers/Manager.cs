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

    static void LoadScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
