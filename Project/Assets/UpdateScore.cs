using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    static TextMeshProUGUI textMP;

    private void Start()
    {
        textMP = GetComponent<TextMeshProUGUI>();
    }
    public static void Update_Score(float score)
    {
        textMP.text = "Success rate: " + score + "%";

        float r, g;

        if (score > 50)
        {
            r = (100 - score) * .5f;
            g = 100;
        }
        else
        {
            r = 100;
            g = (score - 50) * 2;
        }

        r *= 2.55f;
        g *= 2.55f;

        Debug.Log(r + " " + g + " " + 0);

        textMP.color = new Color(r, g, 0);
    }
}
