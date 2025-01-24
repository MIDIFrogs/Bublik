using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float decreaseRate;
    [SerializeField] private float increaseRate;
    [SerializeField] private float gravityMultiplier;
    [SerializeField] private float dragForce;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        body.AddForce(Vector2.right * dragForce);
        transform.localScale -= decreaseRate * Time.fixedDeltaTime * Vector3.one;
        if (transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
        body.gravityScale += decreaseRate * gravityMultiplier * Time.fixedDeltaTime;
    }

    public void Increase()
    {
        transform.localScale += increaseRate * Time.fixedDeltaTime * Vector3.one;
        body.gravityScale -= increaseRate * gravityMultiplier * Time.fixedDeltaTime;
    }
}
