using UnityEngine;

namespace MIDIFrogs.Bubble.Control
{
    public static class InputHandler
    {
        public static Vector2 GetInputPosition()
        {
            if (Input.touchCount > 0)
            {
                return Input.GetTouch(0).position;
            }
            else
            {
                return Input.mousePosition;
            }
        }

        public static bool IsInputPressed()
        {
            if (Input.touchCount > 0)
            {
                return Input.GetTouch(0).phase == TouchPhase.Began ||
                       Input.GetTouch(0).phase == TouchPhase.Moved ||
                       Input.GetTouch(0).phase == TouchPhase.Stationary;
            }
            else
            {
                return Input.GetMouseButton(0);
            }
        }

        public static bool IsAnyKeyPressed() => Input.anyKeyDown || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }
}