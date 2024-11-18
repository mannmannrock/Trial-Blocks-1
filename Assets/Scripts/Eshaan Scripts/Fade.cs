using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeGameObjectToBlack : MonoBehaviour
{
    public float fadeDuration = 2.0f; // Duration of the fade in seconds
    private Renderer objectRenderer;
    private bool isFading = false;
    private float fadeTimer = 0f;

    void Start()
    {
        // Get the Renderer component of the GameObject
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer == null)
        {
            Debug.LogError("No Renderer component found on this GameObject.");
        }
    }

    void Update()
    {

        if (isFading)
        {
            PerformFade();
        }
    }

    public void StartFade()
    {
        isFading = true;
        fadeTimer = 0f;
    }

    void PerformFade()
    {
        fadeTimer += Time.deltaTime;

        if (objectRenderer != null)
        {
            float fadeAmount = fadeTimer / fadeDuration;

            // Get the current material color
            Color currentColor = objectRenderer.material.color;

            // Gradually change color to black
            currentColor = Color.Lerp(currentColor, Color.black, fadeAmount);
            objectRenderer.material.color = currentColor;
        }

        if (fadeTimer >= fadeDuration)
        {
            isFading = false;
        }
    }
}
