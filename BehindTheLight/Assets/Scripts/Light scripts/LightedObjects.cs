using System.Collections;
using UnityEngine;

public class LightedObjects : MonoBehaviour, IInteractable
{
    [SerializeField] private Material mat;
    private float fadeSpeed = 1.5f;
    private Coroutine fadeCoroutine;
    [SerializeField] private string onInteractMsg;

    public string OnInteractMsg => onInteractMsg;

    public void StartFadeIn()
    {
        StartFadeToAlpha(1f);
    }

    public void StartFadeOut()
    {
        StartFadeToAlpha(0f);
    }

    private void StartFadeToAlpha(float alpha)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeTo(alpha));
    }

    /// <summary>
    /// Coroutine that makes the object visible controlling it alpha.
    /// </summary>
    IEnumerator FadeTo(float alpha)
    {
        Color c = mat.color;
        float startAlpha = c.a;

        while (Mathf.Abs(c.a - alpha) > 0.01f)
        {
            c.a = Mathf.MoveTowards(c.a, alpha, fadeSpeed * Time.deltaTime);
            mat.color = c;
            yield return null;
        }

        c.a = alpha;
        mat.color = c;
    }

    public bool IsVisible()
    {
        return mat.color.a > 0.95f;
    }

    public void OnInteract()
    {
        print("Interactuaste");
    }

    private void OnDestroy()
    {
        Color c = mat.color;
        c.a = 0f;
        mat.color = c;
    }
}

