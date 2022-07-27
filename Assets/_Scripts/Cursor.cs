using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster _graphicRaycaster;
    [SerializeField] private EventSystem _eventSystem;

    private PointerEventData _pointerEventData;
    private RaycastHit _raycastHit;
    private ISelectable curUnit;
    private List<RaycastResult> _results;
    Plane PlaneForPick = new Plane(Vector3.up, Vector3.zero);
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _raycastHit))
            {
                if (_raycastHit.transform.TryGetComponent(out ISelectable selectable))
                {
                    curUnit = selectable;
                    selectable.OnSelect();
                }
                else if ((!_raycastHit.transform.TryGetComponent(out ISelectable _selectable)) && curUnit != null)
                {
                    curUnit = null;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _raycastHit) && curUnit != null)
            {
                curUnit.MoveToPos(_raycastHit);
            }
        }
    }

}
if (Input.GetMouseButtonDown(0))
        {
            _pointerEventData = new PointerEventData(_eventSystem);
            _pointerEventData.position = Input.mousePosition;

            _results = new List<RaycastResult>();
            _graphicRaycaster.Raycast(_pointerEventData, _results);

            if (_results.Count == 0)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _raycastHit))
                {
                    if (_raycastHit.transform.TryGetComponent(out ISelectable selectable))
                    {
                        selectable.OnSelect();
                    }
                }
            }
        }
    }
}
