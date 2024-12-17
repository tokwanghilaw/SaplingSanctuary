using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialImageController : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private float fadeDuration = 5f; // Duration of the fade
    private float fadeTime = 0f; // Time passed since the fade started
    private float delayTime = 3f; // Time to wait before starting to fade
    private bool isFading = false; // Flag to check if fading has started

    void Start()
    {
        // Get the CanvasGroup component attached to the GameObject
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            // If there's no CanvasGroup, add one
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        // Ensure the image is fully opaque at the start
        canvasGroup.alpha = 1f;
    }

    void Update()
    {
        // Start fading after the delayTime (3 seconds)
        if (!isFading && fadeTime >= delayTime)
        {
            isFading = true;
        }

        // If fading has started, gradually reduce alpha
        if (isFading)
        {
            fadeTime += Time.deltaTime;

            // Calculate the alpha value for fading
            float alpha = Mathf.Lerp(1f, 0f, (fadeTime - delayTime) / fadeDuration);

            // Apply the new alpha value to the CanvasGroup
            canvasGroup.alpha = alpha;

            // Destroy the image once it has completely faded
            if (fadeTime >= delayTime + fadeDuration)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            // Increment the fade time until the delayTime is reached
            fadeTime += Time.deltaTime;
        }
    }
}
