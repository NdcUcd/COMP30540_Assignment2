using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{

    public static void LoadInfiniteMode()
    {
        GameManager.infiniteMode = true;
        LoadScene("Game");
    }

    public static void LoadStoryMode()
    {
        GameManager.infiniteMode = false;
        LoadScene("Game");
    }

    static void LoadScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
