using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnLevelWasLoaded() {
        if (name == "Canvas AI" && SceneManager.GetActiveScene().buildIndex == 1) transform.GetChild(0).gameObject.SetActive(false);
        else if(name == "Canvas AI" && transform.GetChild(0).gameObject.activeInHierarchy == false) transform.GetChild(0).gameObject.SetActive(true);
    }
}
