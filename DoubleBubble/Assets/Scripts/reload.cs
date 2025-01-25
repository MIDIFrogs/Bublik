using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reload : MonoBehaviour
{
    public bool isMoving = false; 
    public float initialSpeed = 2f; 
    public float acceleration = 0.5f; 
    public Vector2 targetPosition; 

    private Rigidbody2D rb; 
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        currentSpeed = initialSpeed;
    }

    public void ReloadScene()
    {
        isMoving= true;
        //string currentSceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentSceneName);
    }
    void Update()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {

        Vector2 direction = (targetPosition - rb.position).normalized;


        currentSpeed += acceleration * Time.deltaTime;


        rb.MovePosition(rb.position + direction * currentSpeed * Time.deltaTime);


        if (Vector2.Distance(rb.position, targetPosition) < 0.1f)
        {
            isMoving = false; 
        }
    }
}
