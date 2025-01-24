using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private float lifetime;

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
            ball.Increase();
        }
    }
}
