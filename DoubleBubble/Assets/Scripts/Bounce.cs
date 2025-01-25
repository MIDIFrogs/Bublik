using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceForce = 10f; // Сила отпружинивания

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Vector2 normal = collision.contacts[0].normal; 
            rb.AddForce(normal * bounceForce, ForceMode2D.Impulse); 
        }
    }
}