using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceForce = 10f; // Сила отпружинивания
    [SerializeField] AudioSource au1;
    [SerializeField] AudioSource au2;
    [SerializeField] AudioSource au3;
    [SerializeField] AudioSource au4;
    
private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            System.Random random = new System.Random();
            switch (random.Next(1, 3))
            {
                case 1: { au1.Play(); break; }
                case 2: { au2.Play(); break; }
                case 3: { au3.Play(); break; }
                case 4: { au4.Play(); break; }

            }
            Vector2 normal = collision.contacts[0].normal; 
            rb.AddForce(normal * bounceForce, ForceMode2D.Impulse); 
        }
    }
}