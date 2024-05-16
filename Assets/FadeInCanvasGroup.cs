using UnityEngine;

public class FadeInCanvasGroup : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1f;
    private float currentAlpha = 0f;
    private bool isFading = false;

    void Start()
    {
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup not assigned to FadeInCanvasGroup script.");
            enabled = false; // Disable the script if CanvasGroup is not assigned
            return;
        }

        // Set initial alpha to 0 to start with a faded out state
        canvasGroup.alpha = 0f;
    }

    void Update()
    {
        if (isFading)
        {
            // Calculate new alpha value based on time and duration
            currentAlpha += Time.deltaTime / fadeDuration;
            currentAlpha = Mathf.Clamp01(currentAlpha);

            // Apply the new alpha value to the CanvasGroup
            canvasGroup.alpha = currentAlpha;

            // Check if fading is complete
            if (currentAlpha >= 1f)
            {
                isFading = false;
            }
        }
    }

    public void StartFadeIn()
    {
        // Start the fade-in process
        if (canvasGroup.alpha != 0f)
        {
            return;
        }
        isFading = true;
        currentAlpha = 0f;
    }
}
