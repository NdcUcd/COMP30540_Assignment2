using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Link_Scroller_And_Input : MonoBehaviour
{
    Slider slider;
    TMP_InputField inputField;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        inputField = GetComponentInChildren<TMP_InputField>();

        UpdateInputField();
    }

    public void UpdateInputField()
    {
        inputField.text = slider.value.ToString();
    }

    public void UpdateScrollbarValue()
    {
        if (inputField.text != "")
        {
            slider.value = float.Parse(inputField.text);
        }
        else
        {
            slider.value = slider.minValue;
            inputField.text = "";
        }
    }
}
