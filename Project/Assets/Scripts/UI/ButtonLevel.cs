using TMPro;
using UnityEngine;

public class ButtonLevel : MonoBehaviour
{
    int index;
    private void Awake()
    {
        index = transform.GetSiblingIndex() + 1;
        //Debug.Log(GetComponent<Michsky.UI.Shift.QuickMatchButton>().buttonTitle + " " + name);
        GetComponent<Michsky.UI.Shift.QuickMatchButton>().buttonTitle = "LEVEL " + index;
    }
    public void SetLevelValue()
    {
        GameManager.SetLevelNbToLoad(index);
    }
}
