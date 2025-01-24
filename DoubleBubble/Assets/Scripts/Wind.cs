using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float power;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Collision detected");
        collision.GetComponent<Rigidbody2D>().AddForceAtPosition(transform.up * power, collision.ClosestPoint(transform.position));
    }
}
