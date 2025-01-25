using UnityEngine;
using UnityEngine;
using System.Collections;

public class AllFade : MonoBehaviour
{
    [SerializeField] private AudioSource au1;
    [SerializeField] private AudioSource au2;
    [SerializeField] private AudioSource au3;
    [SerializeField] private AudioSource au4;
    [SerializeField] private AudioSource au5;
    [SerializeField] private float crossfadeDuration = 2.0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(au2.volume >= 0.1) StartCoroutine(Crossfade(au2, au1));
            if (au3.volume >= 0.1) StartCoroutine(Crossfade(au3, au1));
            if (au4.volume >= 0.1) StartCoroutine(Crossfade(au4, au1));
            if (au5.volume >= 0.1) StartCoroutine(Crossfade(au5, au1));
        }
    }

    private IEnumerator Crossfade(AudioSource audioSource1, AudioSource audioSource2)
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
