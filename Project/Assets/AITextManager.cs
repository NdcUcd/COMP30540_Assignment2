using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AITextManager : MonoBehaviour
{
    [TextArea(8, 20)]
    [SerializeField] List<string> texts = new List<string>();
    TextMeshProUGUI textMP;
    Image panel;

    string textToDisplay;

    [Range(0, 0.1f)]
    [SerializeField] float initialTimeBetweenLetters;
    float currentTimeBetweenLetters;

    int letterIndextoDisplay;

    void Start()
    {
        textMP = GetComponentInChildren<TextMeshProUGUI>();
        panel = GetComponentInChildren<Image>();
        Init();
        SetTextToDisplay(0);
    }

    void Update()
    {
        if (letterIndextoDisplay >= textToDisplay.Length) return;

        currentTimeBetweenLetters -= Time.deltaTime;

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
        if(!panel.IsActive()) panel.enabled = true;

        textToDisplay = texts[textIndex];
        Init();
    }

    public void GoingBack()
    {
        panel.enabled = false;
        textMP.text = "";
    }
}
