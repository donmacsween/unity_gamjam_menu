using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollSnap : MonoBehaviour , ISelectHandler
{
    [SerializeField] 
    private ScrollRect scrollRect;
    // The panel within our scrollrect
    [SerializeField]
    private RectTransform contentPanel;
    
    public void OnSelect(BaseEventData eventData)
    {
        // Get the rectTransform of the object that has just been selected 
        RectTransform target = eventData.selectedObject.GetComponent(typeof(RectTransform)) as RectTransform;
        // RectTransform panel = scrollRect.GetComponent(typeof(RectTransform)) as RectTransform;
        // set the position of the content panel in the scroll panel by calculating the offset
        //if (panel.rect.Contains(target.position)) {
            contentPanel.anchoredPosition =
             (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
              - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);
        //}
    }
}
