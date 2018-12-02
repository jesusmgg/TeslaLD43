using UnityEngine;

namespace Tesla.Controls
{
    public class MouseControls : BaseControls
    {
        Camera cam;

        void Start()
        {
            cam = FindObjectOfType<Camera>();
        }

        public bool GetMouseButtonDown(int button)
        {
            return Input.GetMouseButtonDown(button);
        }

        public Vector2 GetMouseWorldPosition()
        {
            Vector2 mousePos = new Vector2
            {
                x = Input.mousePosition.x,
                y = Input.mousePosition.y
            };

            return cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
        }
    }
}