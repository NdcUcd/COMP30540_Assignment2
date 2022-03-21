using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayTextOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject textAI_gameObject;

    [TextArea(5, 10)]
    [SerializeField] string informationText;
    public void OnPointerEnter(PointerEventData eventData)
    {
        textAI_gameObject.GetComponent<AITextManager>().ReinitTextPanel();
        textAI_gameObject.GetComponentInChildren<TextMeshProUGUI>().text = informationText;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textAI_gameObject.GetComponentInChildren<TextMeshProUGUI>().text = textAI_gameObject.GetComponent<AITextManager>().texts[3];
    }
}
