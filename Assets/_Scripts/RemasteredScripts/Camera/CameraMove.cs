using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInit.GameCyrcleModule;


namespace GameInit.Camera
{
	public class CameraMove : ICallable
	{
		private CameraSettings settings;
		
		private Vector3 offset;
		private Vector3 lastPos = Vector3.zero;
		private Transform cameraTransform;

		private int speedMultiplay = 100;
		private bool drag = false;

		private const int constY = 0;

		public CameraMove(CameraSettings _settings, Transform _cameraTransform)
		{
			settings = _settings;
			cameraTransform = _cameraTransform;
		}
		private void MoveController()
		{
			if (!drag)
			{
				Vector3 pos = cameraTransform.position;
				if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - settings.panBorderThicknes)
				{
					pos.z += settings.speed * Time.deltaTime;
				}
				if (Input.GetKey("s") || Input.mousePosition.y <= settings.panBorderThicknes)
				{
					pos.z -= settings.speed * Time.deltaTime;
				}
				if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - settings.panBorderThicknes)
				{
					pos.x += settings.speed * Time.deltaTime;
				}
				if (Input.GetKey("a") || Input.mousePosition.x <= settings.panBorderThicknes)
				{
					pos.x -= settings.speed * Time.deltaTime;
				}

				float scroll = Input.GetAxis("Mouse ScrollWheel");
				pos.y -= scroll * settings.scrollSpeed * speedMultiplay * Time.deltaTime;

				pos.x = Mathf.Clamp(pos.x, -settings.limitPan.x, settings.limitPan.x);
				pos.y = Mathf.Clamp(pos.y, settings.minHight, settings.maxHight);
				pos.z = Mathf.Clamp(pos.z, -settings.limitPan.y, settings.limitPan.y);

				cameraTransform.position = pos;
			}
		}

		private void DragAndDropCameraMove()
		{

			if (Input.GetMouseButton(2))
			{
				float h = settings.dragSpeed * Input.GetAxis("Mouse X");
				float v = settings.dragSpeed * Input.GetAxis("Mouse Y");
				lastPos = cameraTransform.position;
				offset = new Vector3(h, constY, v);
				drag = true;
			}
			else
			{
				drag = false;
			}
			if (drag)
			{
				lastPos = Vector3.Lerp(lastPos, cameraTransform.position - offset, 0.5f);
				cameraTransform.position = lastPos;
			}
		}

        public void UpdateCall()
        {
			MoveController();
			DragAndDropCameraMove();
		}
    }
}

