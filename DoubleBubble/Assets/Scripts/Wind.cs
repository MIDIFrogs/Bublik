using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private float lifetime;
    [SerializeField] private AudioSource au1;
    [SerializeField] private AudioSource au2;
    [SerializeField] private AudioSource au3;
    bool flag = false;
    private void FixedUpdate()
    {
        lifetime -= Time.fixedDeltaTime;
        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        collision.GetComponent<Rigidbody2D>().AddForceAtPosition(transform.up * power, collision.ClosestPoint(transform.position));
        if (collision.TryGetComponent<Ball>(out var ball))
        {
            if (!flag)
            {
                System.Random random = new System.Random();
                switch (random.Next(1, 3))
                {
                    case 1: { au1.Play(); break; }
                    case 2: { au2.Play(); break; }
                    case 3: { au3.Play(); break; }
                }
                flag = true;
            }
            ball.Increase();
        }
    }
}
