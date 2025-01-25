using UnityEngine;
using System.Collections;

public class CrossFade : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource1; 
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private float crossfadeDuration = 2.0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(Crossfade());
        }
    }

    private IEnumerator Crossfade()
    {
        float time = 0f;

        while (time < crossfadeDuration)
        {
            time += Time.deltaTime;
            float t = time / crossfadeDuration;

            audioSource1.volume = 1.0f - t; 
            audioSource2.volume = t; 

            yield return null; 
        }

        audioSource1.volume = 0.0f;
        audioSource2.volume = 1.0f;
    }
}
