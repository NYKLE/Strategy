using UnityEngine;

public class Cursor : MonoBehaviour
{
    private RaycastHit _raycastHit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
