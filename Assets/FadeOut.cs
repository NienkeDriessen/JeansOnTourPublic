using UnityEngine;

public class FadeOut : MonoBehaviour
{
    CanvasGroup canvasGroup;
    bool isFading = false;
    float fadeDuration = 1f; // Duration of the fade effect in seconds
    float fadeTimer = 0f;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        // Check if fading is already in progress or if there are no touches
        if (isFading || Input.touchCount == 0)
            return;

        // Start fading
        isFading = true;
        fadeTimer = 0f;
    }

    void FixedUpdate()
    {
        // Check if fading is in progress
        if (isFading)
        {
            // Increment the fade timer
            fadeTimer += Time.fixedDeltaTime;

            // Calculate the alpha value based on the fade timer
            float alpha = 1f - Mathf.Clamp01(fadeTimer / fadeDuration);

            // Set the alpha value of the CanvasGroup
            canvasGroup.alpha = alpha;

            // Check if fading is complete
            if (fadeTimer >= fadeDuration)
            {
                // Ensure the alpha value is set to 0
                canvasGroup.alpha = 0f;

            }
        }
    }
}
