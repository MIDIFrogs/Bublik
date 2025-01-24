using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float sizeDrainRate;
    [SerializeField] private float gravityGainRate;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.localScale -= sizeDrainRate * Time.fixedDeltaTime * Vector3.one;
        if (transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
        body.gravityScale += gravityGainRate * Time.fixedDeltaTime;
    }
}
