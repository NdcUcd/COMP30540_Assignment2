using UnityEngine;

public class ButtonLevel : MonoBehaviour
{
    int index;
    private void Awake()
    {
        string buttonText;

        index = transform.GetSiblingIndex() + 1;

        if (index < transform.parent.childCount)
            buttonText = "LEVEL " + index;
        else
            buttonText = "FINAL LEVEL";

        GetComponent<Michsky.UI.Shift.QuickMatchButton>().buttonTitle = buttonText;
    }

    public void SetLevelValue()
    {
        GameManager.SetLevelNbToLoad(index);
    }
}
