using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using MIDIFrogs.Bubble.Control;

namespace MIDIFrogs.Bubble.Cutscenes
{
    public class ImageFader : MonoBehaviour
    {
        [SerializeField] private Image[] images;
        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private float endDelay;
        [SerializeField] private UnityEvent onSlideshowEnd;

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
            for (float delay = 0; delay < endDelay; delay += Time.unscaledDeltaTime)
            {
                if (InputHandler.IsAnyKeyPressed())
                    break;
                yield return new WaitForEndOfFrame();
            }
            onSlideshowEnd.Invoke();
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
                if (InputHandler.IsAnyKeyPressed())
                    break;
                yield return null;
            }

            color.a = 1;
            img.color = color;
        }
    }
}