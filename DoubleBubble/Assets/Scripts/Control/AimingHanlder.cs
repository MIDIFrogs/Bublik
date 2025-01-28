using UnityEngine;

namespace MIDIFrogs.Bubble.Control
{
    /// <summary>
    /// Represents an object that handles wind aiming.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class AimingHandler : MonoBehaviour
    {
        [SerializeField] private GameObject arrowPrefab;
        [SerializeField] private Wind windPrefab;
        [SerializeField] private Transform anchor;
        [SerializeField] private AudioClip[] clips;

        private AudioSource audioSource;

        private Wind currentWind;

        private bool isPressing;
        private Vector3 beginLocation;
        private GameObject arrow;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            Vector3 location = Camera.main.ScreenToWorldPoint(InputHandler.GetInputPosition());
            location.z = 0;
            bool inputDown = InputHandler.IsInputPressed();

            if (inputDown && !isPressing)
            {
                CreateArrowWireframe(location);
            }
            else if (!inputDown && isPressing)
            {
                Destroy(arrow);
                isPressing = false;
                SummonNewWind(location);
            }

            if (!isPressing)
                return;

            UpdateArrowPosition(location);
        }

        /// <summary>
        /// Creates an arrow texture at the specified location.
        /// </summary>
        /// <param name="location">Location to create arrow at.</param>
        private void CreateArrowWireframe(Vector3 location)
        {
            isPressing = true;
            beginLocation = location;
            arrow = Instantiate(arrowPrefab, beginLocation, Quaternion.identity);
        }

        /// <summary>
        /// Draws an arrow between initial and current locations.
        /// </summary>
        /// <param name="location">Current location to draw arrow to.</param>
        private void UpdateArrowPosition(Vector3 location)
        {
            arrow.transform.right = (location - beginLocation).normalized;
            arrow.transform.position = (location + beginLocation) / 2;
            arrow.transform.localScale = Vector3.one * Vector3.Distance(location, beginLocation);
        }

        /// <summary>
        /// Creates new wind at the specified position.
        /// </summary>
        /// <param name="location">Location to summon wind at.</param>
        private void SummonNewWind(Vector3 location)
        {
            if (currentWind != null)
            {
                Destroy(currentWind.gameObject);
            }

            audioSource.PlayOneShot(clips.RandomChoice());

            var wind = Instantiate(windPrefab, (location + beginLocation) / 2, Quaternion.LookRotation(Vector3.forward, (location - beginLocation).normalized), anchor);
            var distance = Vector3.Distance(location, beginLocation);
            wind.transform.localScale = new Vector3(distance / 2, distance, 1);
            currentWind = wind;
        }
    }
}