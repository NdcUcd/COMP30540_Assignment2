using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public void Load_Scene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}