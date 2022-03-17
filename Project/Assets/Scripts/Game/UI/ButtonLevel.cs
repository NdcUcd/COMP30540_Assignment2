using TMPro;
using UnityEngine;

public class ButtonLevel : MonoBehaviour
{
    int index;
    private void Start()
    {
        index = transform.GetSiblingIndex() + 1;
        GetComponentInChildren<TextMeshProUGUI>().text = "Level " + index;
    }
    public void SetLevelValue()
    {
        GameManager.SetLevelNbToLoad(index);
    }
}
