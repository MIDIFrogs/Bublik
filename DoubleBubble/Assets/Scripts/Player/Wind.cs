using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private AudioClip[] clips;
    
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clips.RandomChoice());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().AddForceAtPosition(transform.up * power, collision.ClosestPoint(transform.position));
        if (collision.TryGetComponent<Bubble>(out var ball))
        {
            ball.Increase();
        }
    }
}