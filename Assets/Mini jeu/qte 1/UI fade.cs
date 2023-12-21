using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFader : MonoBehaviour
{
    public float fadeDuration = 1.0f;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        // Assurez-vous que le GameObject possède un composant CanvasGroup
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void Disapear()
    {
        canvasGroup.alpha = 0;
    }

    public void fadeOut()
    {
        canvasGroup.alpha = 0.3f;
    }

    public void fadeIn()
    {
        canvasGroup.alpha = 1;
    }
}
