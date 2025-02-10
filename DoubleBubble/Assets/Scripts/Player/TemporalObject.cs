using UnityEngine;

namespace MIDIFrogs.Bubble.Player
{
	public class TemporalObject : MonoBehaviour
	{
		[SerializeField] private float lifetime;

        private void FixedUpdate()
        {
            lifetime -= Time.fixedDeltaTime;
            if (lifetime < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}