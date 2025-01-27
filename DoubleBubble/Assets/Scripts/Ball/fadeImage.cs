using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ImageFader : MonoBehaviour
{
    public Image[] images; 
    public float fadeDuration = 1f; 

    private void Start()
    {
        StartCoroutine(FadeInImages());
    }

    private IEnumerator FadeInImages()
    {
        foreach (Image img in images)
        {
            yield return StartCoroutine(FadeIn(img));
        }
    }

    private IEnumerator FadeIn(Image img)
    {
        Color color = img.color;
        color.a = 0; 
        img.color = color; 

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration); 
            img.color = color; 
            yield return null; 
        }

        color.a = 1; 
        img.color = color; 
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            SceneManager.LoadScene("Tutorial 1");
        }
    }
}
