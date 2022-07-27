using UnityEngine;

public class UIBillboard : MonoBehaviour
{
    private Transform _cameraTransform;

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _cameraTransform.rotation * Vector3.forward, _cameraTransform.rotation * Vector3.up);
    }
}
