using UnityEngine;
using UnityEngine.Events;

public class Bubble : MonoBehaviour
{
    [Header("Physical properties")]
    [SerializeField] private float decreaseRate;
    [SerializeField] private float gravityMultiplier;
    [SerializeField] private float increaseRate;
    [SerializeField] private float maxSize;

    [Header("Interactivity")]
    [SerializeField] private UnityEvent onPlayerDied;

    private AudioSource audioSource;
    private Animator anim;
    private Rigidbody2D body;
    private bool isDied = false;
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

    public void Burst() => Die();

    public void Collapse() => Die();

    public void Decrease()
    {
        if (IsFrozen)
            return;
        Size -= decreaseRate * Time.fixedDeltaTime;
    }

    public void Die()
    {
        if (!isDied)
        {
            isDied = true;
            audioSource.Play();
            anim.SetBool("IsAlive", false);
            body.linearVelocity = Vector2.zero;
            Invoke(nameof(Kill), 0.75f);
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
        onPlayerDied.Invoke();
        isDied = false;
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
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (isDied)
            return;

        Decrease();
        if (Size <= 0)
        {
            Collapse();
        }
        if (Size >= maxSize)
        {
            Burst();
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