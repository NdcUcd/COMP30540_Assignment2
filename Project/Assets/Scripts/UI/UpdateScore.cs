using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    static TextMeshProUGUI textMP;

    private void Awake()
    {
        textMP = GetComponent<TextMeshProUGUI>();
    }

    public static void Update_Score(float score)
    {
        textMP.text = "Success rate: " + score + "%";

        //float r, g;

        //if (score > 50)
        //{
        //    r = (100 - score) * .5f;
        //    g = 100;
        //}
        //else
        //{
        //    r = 100;
        //    g = 255 - score * 2.55f * 2;
        //}

        //r *= 2.55f;
        //g *= 2.55f;

        //Debug.Log(r + " " + g + " " + 0);

        //textMP.color = new Color(r, g, 0);
    }
}
