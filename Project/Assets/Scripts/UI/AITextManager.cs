using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AITextManager : MonoBehaviour
{
    [TextArea(8, 20)]
    public List<string> texts = new List<string>();
    TextMeshProUGUI textMP;
    Image panel;

    string textToDisplay;
    bool displayText;

    [Range(0, 0.1f)]
    [SerializeField] float initialTimeBetweenLetters;
    float currentTimeBetweenLetters;

    int letterIndextoDisplay;

    void OnEnable()
    {
        textMP = GetComponentInChildren<TextMeshProUGUI>();
        panel = GetComponentInChildren<Image>();
        Init();
        SetTextToDisplay(0);
    }

    void Update()
    {
        if (letterIndextoDisplay >= textToDisplay.Length || !displayText) return;

        currentTimeBetweenLetters -= Time.unscaledDeltaTime;

        if (currentTimeBetweenLetters <= 0)
        {
            DisplayNextLetter();
            currentTimeBetweenLetters = initialTimeBetweenLetters;
        }
    }

    void DisplayNextLetter()
    {
        textMP.text += textToDisplay[letterIndextoDisplay];
        letterIndextoDisplay++;
    }

    void Init()
    {
        letterIndextoDisplay = 0;
        textMP.text = "";
        currentTimeBetweenLetters = initialTimeBetweenLetters;
    }

    public void SetTextToDisplay(int textIndex)
    {
        displayText = true;

        if (!panel.IsActive()) panel.enabled = true;

        textToDisplay = texts[textIndex];
        Init();
    }

    public void ReinitTextPanel()
    {
        textMP.text = "";
        displayText = false;
    }

    public void GoingBack()
    {
        ReinitTextPanel();
        panel.enabled = false;
    }
}
