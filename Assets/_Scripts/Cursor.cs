using UnityEngine;

public class Cursor : MonoBehaviour
{
    private RaycastHit _raycastHit;
    private ISelectable curUnit;
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
