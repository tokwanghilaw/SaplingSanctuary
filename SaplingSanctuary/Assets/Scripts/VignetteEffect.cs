using System.Collections; // Required for IEnumerator
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteEffect : MonoBehaviour
{
    public Transform player; // Reference to the player
    public Collider2D baseArea; // Collider marking the base
    public Volume globalVolume; // The Global Volume for post-processing

    private Vignette vignette;
    private bool isOutsideBase = false;
    private float intensity = 0.2f;
    private float maxIntensity = 1f;
    private float duration = 60f; // Duration in seconds

    void Start()
    {
        // Access the Vignette effect in the Volume
        if (globalVolume.profile.TryGet(out vignette))
        {
            vignette.intensity.value = intensity;
        }
    }

    void Update()
    {
        // Check if the player is outside the base
        bool currentlyOutsideBase = !baseArea.bounds.Contains(player.position);

        if (currentlyOutsideBase && !isOutsideBase)
        {
            // Player just left the base
            isOutsideBase = true;
            StopAllCoroutines();
            StartCoroutine(ChangeVignetteIntensity(intensity, maxIntensity, duration));
        }
        else if (!currentlyOutsideBase && isOutsideBase)
        {
            // Player returned to the base
            isOutsideBase = false;
            StopAllCoroutines();
            StartCoroutine(ChangeVignetteIntensity(vignette.intensity.value, intensity, 0.5f)); // Quick reset
        }
    }

    private IEnumerator ChangeVignetteIntensity(float start, float end, float time)
    {
        float elapsed = 0f;

        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);
            vignette.intensity.value = Mathf.Lerp(start, end, t);
            yield return null;
        }

        vignette.intensity.value = end;
    }
}