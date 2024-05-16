using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image fadeImage;
    public GameObject fadeImageGameObject;
    public float fadeDuration = 1f;

    private Color transparentColor = new Color(0f, 0f, 0f, 0f);
    private Color opaqueColor = new Color(0f, 0f, 0f, 1f);
    private bool isFading = false;

    public void Start()
    {
        FadeIn();
    }

    public void FadeIn()
    {
        if (!isFading)
        {
            isFading = true;
            fadeImage.gameObject.SetActive(true);
            fadeImage.color = opaqueColor;
            StartCoroutine(FadeImage(fadeImage, transparentColor));
        }
    }

    public void FadeOut()
    {
        if (!isFading)
        {
            isFading = true;
            fadeImage.gameObject.SetActive(true);
            fadeImage.color = transparentColor;
            StartCoroutine(FadeImage(fadeImage, opaqueColor));
        }
    }

    private IEnumerator FadeImage(Image image, Color targetColor)
    {
        float timer = 0f;
        Color startColor = image.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            image.color = Color.Lerp(startColor, targetColor, timer / fadeDuration);
            yield return null;
        }

        image.color = targetColor;
        if (targetColor.a == 0f)
        {
            fadeImage.gameObject.SetActive(false);
            fadeImageGameObject.SetActive(false);
        }
        isFading = false;
    }
}
