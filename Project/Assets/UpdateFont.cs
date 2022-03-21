using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateFont : MonoBehaviour
{
    [SerializeField] TMP_FontAsset font;

    void Start()
    {
        UpdateTextFont();
    }

    void UpdateTextFont()
    {
        TextMeshProUGUI[] texts = FindObjectsOfType<TextMeshProUGUI>();

        foreach (TextMeshProUGUI text in texts)
            text.font = font;
    }
}
