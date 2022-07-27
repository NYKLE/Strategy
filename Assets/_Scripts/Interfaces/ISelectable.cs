using UnityEngine;
public interface ISelectable
{
    void OnSelect();
    void MoveToPos(RaycastHit hit);
}
