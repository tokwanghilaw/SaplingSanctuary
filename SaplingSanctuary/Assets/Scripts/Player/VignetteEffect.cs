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

    public static float currIntensity;  // Public static variable for intensity
    private float targetIntensity;
    private float intensityChangeSpeed;

    public float timer;

    void Start()
    {
        // Access the Vignette effect in the Volume
        if (globalVolume.profile.TryGet(out vignette))
        {
            vignette.intensity.value = intensity;
        }

        targetIntensity = intensity;  // Initial target intensity is the base intensity
        timer = 0.2f;
    }

    void Update()
    {
        if (!PlayerMovement.isInsideBase) // Outside the base
        {
            //intensityChangeSpeed = Mathf.Abs(maxIntensity - currIntensity) / duration;
            //targetIntensity = maxIntensity;
            //timer = (1 / 60) * Time.deltaTime;
            vignette.intensity.value = timer;
            //Debug.Log("Current Vignette Intensity / Outside Base: " + currIntensity);
            currIntensity = vignette.intensity.value;
        }
        else // Inside the base
        {
            //intensityChangeSpeed = Mathf.Abs(intensity - currIntensity) / 0.5f; // Quick reset
            //targetIntensity = intensity;
            timer = 0.2f;
            vignette.intensity.value = intensity;
            //Debug.Log("Current Vignette Intensity / Inside Base: " + currIntensity);
            currIntensity = vignette.intensity.value;
        }
        timer += (1f / 60) * Time.deltaTime;
    }
}