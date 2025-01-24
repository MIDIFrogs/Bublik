using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalWindVelocity : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
    }
}
