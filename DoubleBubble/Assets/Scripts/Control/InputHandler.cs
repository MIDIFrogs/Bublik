using UnityEngine;

namespace MIDIFrogs.Bubble.Control
{
    /// <summary>
    /// Represents a unified input service.
    /// </summary>
    public static class InputHandler
    {
        /// <summary>
        /// Gets current input point (if available).
        /// </summary>
        /// <returns>Main input position in pixel coordinates.</returns>
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

        /// <summary>
        /// Checks if any of inputs is currently pressed.
        /// </summary>
        /// <returns><see langword="true"/> if any touches or mouse click detected; otherwise <see langword="false"/></returns>
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

        /// <summary>
        /// Checks if any key is currently pressed or input is pressed at the current frame.
        /// </summary>
        /// <returns><see langword="true"/> if any input key is pressed; otherwise <see langword="false"/>.</returns>
        public static bool IsAnyKeyPressed() => Input.anyKeyDown || IsInputPressed();
    }
}