using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIClose : Graphic,  IPointerClickHandler
{
    [SerializeField] private Canvas _canvas;

    public void OnPointerClick(PointerEventData eventData)
    {
        _canvas.enabled = false;
    }
}
