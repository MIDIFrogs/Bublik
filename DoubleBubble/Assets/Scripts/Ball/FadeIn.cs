using UnityEngine;
using System.Collections;

public class MusicFadeIn : MonoBehaviour
{
    public AudioSource audioSource; // ���������� ���� ��� AudioSource � ����������
    public float fadeDuration = 2.0f; // ������������ ������� fade in

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        audioSource.volume = 0.1f; // ������������� ��������� ��������� � 0
        audioSource.Play(); // ��������� ������

        float startVolume = audioSource.volume;

        // ���������� ����������� ���������
        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeDuration;
            yield return null; // ���� ���������� �����
        }

        audioSource.volume = 1.0f; // ��������, ��� ��������� ����������� � 1
    }
}
