using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScrolling : MonoBehaviour
{
    [SerializeField] List<string> texts = new List<string>();
    TextMeshProUGUI textMP;

    string textToDisplay;

    [Range(0, 0.1f)]
    [SerializeField] float initialTimeBetweenLetters;
    float currentTimeBetweenLetters;

    int letterIndextoDisplay;

    void Start()
    {
        textMP = GetComponentInChildren<TextMeshProUGUI>();
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
        textToDisplay = texts[textIndex];
        Init();
    }
}
