using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float decreaseRate;
    [SerializeField] private float dragForce;
    [SerializeField] private float gravityMultiplier;
    [SerializeField] private float increaseRate;
    [SerializeField] private float maxSize;
    [SerializeField] private GameObject LoseScreen; 

    private Rigidbody2D body;
    private bool isFrozen;

    public bool IsFrozen
    {
        get => isFrozen;
        set
        {
            isFrozen = value;
            UpdateGravity();
        }
    }

    public float Size
    {
        get => transform.localScale.x;
        set
        {
            transform.localScale = Vector3.one * value;
            if (!isFrozen)
            {
                UpdateGravity();
            }
        }
    }

    public void ApplyWind()
    {
        body.AddForce(Vector2.right * dragForce);
    }

    public void Burst()
    {
        if (IsFrozen)
            return;
        Die();
    }

    public void Collapse()
    {
        Die();
    }

    public void Decrease()
    {
        if (IsFrozen)
            return;
        Size -= decreaseRate * Time.fixedDeltaTime;
    }

    public void Die()
    {
        Destroy(gameObject);
        LoseScreen.SetActive(true);
    }

    public void Increase()
    {
        if (IsFrozen)
            return;
        Size += increaseRate * Time.fixedDeltaTime;
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ApplyWind();
        Decrease();
        if (transform.localScale.x <= 0)
        {
            Collapse();
        }
        if (transform.localScale.x >= maxSize)
        {
            Burst();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            IsFrozen = !IsFrozen;
        }
    }

    private void UpdateGravity()
    {
        if (IsFrozen)
        {
            body.gravityScale = 1;
        }
        else
        {
            body.gravityScale = gravityMultiplier * (1 - Size);
        }
    }
}