using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cinematiqueManager : MonoBehaviour
{
    [Header("References")]
    public CanvasGroup fadeAll;
    public GameObject[] currentCine;

    [Header("Stats")]
    public float fadeTimer;

    int CountIn;
    int CountOut;

    private void Start()
    {
        StartCoroutine(fadeIn());

        currentCine[3].SetActive(true);
    }

    public void fadeEnter()
    {
        StartCoroutine(fadeIn());
    }
    public void fadeExit()
    {
        StartCoroutine(fadeOut());
    }

    public IEnumerator fadeIn()
    {
        if(CountIn > 40)
        {
            yield return null;
        }
        else
        {
            CountIn++;
            fadeAll.alpha += 0.05f;
            yield return new WaitForSeconds(fadeTimer/2);
            StartCoroutine(fadeIn());
        }
    }

    public IEnumerator fadeOut()
    {
        if (CountOut > 40)
        {
            SceneManager.LoadScene(2);
            yield return null;
        }
        else
        {
            CountOut++;
            fadeAll.alpha -= 0.05f;
            yield return new WaitForSeconds(fadeTimer/2);
            StartCoroutine(fadeOut());
        }
    }
}
