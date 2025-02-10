using UnityEngine;

namespace MIDIFrogs.Bubble.Levels
{
    public class Thorn : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<global::Bubble>(out var ball))
            {
                ball.Burst();
            }
        }
    }
}