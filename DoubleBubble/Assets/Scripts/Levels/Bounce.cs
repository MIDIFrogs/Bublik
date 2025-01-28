using UnityEngine;

namespace MIDIFrogs.Bubble.Levels
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bounce : MonoBehaviour
    {
        [SerializeField] float bounceForce = 10f;
        [SerializeField] private AudioClip[] clips;

        private AudioSource audioSource;
        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("wall"))
            {
                audioSource.PlayOneShot(clips.RandomChoice());
                Vector2 normal = collision.contacts[0].normal;
                rb.AddForce(normal * bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}