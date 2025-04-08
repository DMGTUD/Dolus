using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MenuSelectionHilight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string originalText;


    void Start()
    {
        originalText=GetComponentInChildren<TMPro.TextMeshProUGUI>().text;
    }

    public void UpdateOriginalText(string newText)
    {
        if(originalText!=newText)
        {
            originalText=newText;
            ManualChange();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text=">"+originalText;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text=originalText;
    }

    public void ManualChange()
    {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text=originalText;
    }
}
