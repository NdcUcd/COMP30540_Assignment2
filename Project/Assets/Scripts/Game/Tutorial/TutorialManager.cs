using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject AI;
    // Start is called before the first frame update
    void OnEnable()
    {
        AI.SetActive(true);
        GameObject.Find("Player ship").SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
