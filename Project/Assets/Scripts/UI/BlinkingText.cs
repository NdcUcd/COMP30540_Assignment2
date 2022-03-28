using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BlinkingText : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;
    [SerializeField] float originalBlinkingRate;
    float blinkingRate;
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        blinkingRate = originalBlinkingRate;
        Debug.Log(originalBlinkingRate);
    }

    void Update()
    {
        blinkingRate -= Time.unscaledTime;
        Debug.Log(blinkingRate);

        if (blinkingRate <= 0) ToggleText();
    }

    private void ToggleText()
    {
        textMeshProUGUI.enabled = !textMeshProUGUI.enabled;
        blinkingRate = originalBlinkingRate;
    }
}
