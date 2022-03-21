using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateLevel_UI : MonoBehaviour
{
    static TextMeshProUGUI textMP;

    void Start()
    {
        textMP = GetComponent<TextMeshProUGUI>();
    }

    public static void Update_Level() {
        int level = Level.Level_Number;

        if(level == 0)
        {
            textMP.text = "To infinity and beyond...";
            return;
        }

        textMP.text = "Level " + Level.Level_Number; 
    }
}
