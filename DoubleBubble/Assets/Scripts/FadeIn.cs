using UnityEngine;
using System.Collections;

public class MusicFadeIn : MonoBehaviour
{
    public AudioSource audioSource; // Перетащите сюда ваш AudioSource в инспекторе
    public float fadeDuration = 2.0f; // Длительность эффекта fade in

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        audioSource.volume = 0.1f; // Устанавливаем начальную громкость в 0
        audioSource.Play(); // Запускаем музыку

        float startVolume = audioSource.volume;

        // Постепенно увеличиваем громкость
        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeDuration;
            yield return null; // Ждем следующего кадра
        }

        audioSource.volume = 1.0f; // Убедимся, что громкость установлена в 1
    }
}
