using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
	[SerializeField] private int speed;
	[SerializeField] private int minHight;
	[SerializeField] private int maxHight;
	[SerializeField] private int scrollSpeed;
	[SerializeField] private int panBorderThicknes;
	[SerializeField] private Vector2 limitPan;
	[SerializeField] private Camera cameraMain;

	[SerializeField] private Vector3 originPos;
	[SerializeField] private Vector3 offset;

	private int speedMultiplay = 100;
	private bool drag = false;
    private void Update()
    {
		MoveController();
		DragAndDropCameraMove();
	}
    private void MoveController()
	{
		Vector3 pos = cameraMain.transform.position;
		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThicknes)
        {
			pos.z += speed * Time.deltaTime;
        }
		if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThicknes)
		{
			pos.z -= speed * Time.deltaTime;
		}
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThicknes)
		{
			pos.x += speed * Time.deltaTime;
		}
		if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThicknes)
		{
			pos.x -= speed * Time.deltaTime;
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		pos.y -= scroll * scrollSpeed * speedMultiplay * Time.deltaTime;

		pos.x = Mathf.Clamp(pos.x, -limitPan.x, limitPan.x);
		pos.y = Mathf.Clamp(pos.y, minHight, maxHight);
		pos.z = Mathf.Clamp(pos.z, -limitPan.y, limitPan.y);

		cameraMain.transform.position = pos;
    }

	private void DragAndDropCameraMove()
    {
        if (Input.GetMouseButton(2))
        {
			offset = new Vector3(cameraMain.ScreenToViewportPoint(Input.mousePosition).x, cameraMain.transform.position.y, cameraMain.ScreenToViewportPoint(Input.mousePosition).y) - cameraMain.transform.position;
			if (drag == false)
            {
				drag = true;
				originPos = new Vector3(cameraMain.ScreenToViewportPoint(Input.mousePosition).x, cameraMain.transform.position.y, cameraMain.ScreenToViewportPoint(Input.mousePosition).y);
			}
		}
        else
        {
			drag = false;
        }
        if (drag)
        {
			cameraMain.transform.position = originPos - offset;
        }
    }

}