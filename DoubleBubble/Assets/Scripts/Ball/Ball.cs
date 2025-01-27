using Cinemachine;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float decreaseRate;
    [SerializeField] private float dragForce;
    [SerializeField] private float gravityMultiplier;
    [SerializeField] private float increaseRate;
    [SerializeField] private float maxSize;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject LoseScreen;
    [SerializeField] private float transitionSpeed;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource killAudio;
    public WhenPlayerDied WhenPlayerDied { get; set; }

    public Transform[] targets; 
    private int currentTargetIndex = 0;


    private Rigidbody2D rb;
    private float currentSpeed;
    private Rigidbody2D body;
    private bool isDied = false;


    public float Size
    {
        get => transform.localScale.x;
        set
        {
            transform.localScale = Vector3.one * value;
        }
    }

    public void ApplyWind()
    {
        body.AddForce(Vector2.right * dragForce);
    }

    public void Burst()
    {
        Die();
    }

    public void Collapse()
    {
        Die();
    }

    public void Decrease()
    {
        Size -= decreaseRate * Time.fixedDeltaTime;
    }

    public void Die()
    {
        if (!isDied)
        {
            isDied = true;
            killAudio.Play();
            anim.SetBool("IsAlive", false);
            Invoke("Kill", 0.75f);
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
        WhenPlayerDied.SpawnPrefab();
        isDied = false; 
        //LoseScreen.SetActive(true);
    }

    public void Increase()
    {
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

    }

}