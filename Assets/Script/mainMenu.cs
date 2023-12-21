using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class mainMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CanvasGroup[] fade;
    [SerializeField] GameObject[] menuSwitch;
    [SerializeField] AudioSource mainTheme;

    [Header("Stats")]
    public float fadeFactor;
    public AudioSource theme;

    bool Begin;
    int startCount;

    private void Awake()
    {
        Avancement.phase = 0;
        Avancement.FxVol = 1;
        Avancement.MusVol = 1;
    }

    void Update()
    {
        if (!Begin && fade[0].alpha < 1)
        {
            for (int i = 0; i < fade.Length; i++)
            {
                fade[i].alpha += 0.01f;
            }
        }

        // set mus vol to choosen value in the option menu
        mainTheme.volume = Avancement.MusVol;
    }

    public void startGame()
    {
        Begin = true;
        StartCoroutine(fadeOut());
    }

    public void OpenOptions()
    {
        menuSwitch[0].SetActive(false);
        menuSwitch[1].SetActive(true);
    }

    public void CloseOption()
    {
        menuSwitch[0].SetActive(true);
        menuSwitch[1].SetActive(false);
    }
    
    public IEnumerator fadeOut()
    {
        for (int i = 0; i < fade.Length; i++)
        {
            fade[i].alpha -= 0.01f;
        }
        theme.volume-=0.01f;
        startCount++;
        Debug.Log(startCount);
        yield return new WaitForSeconds(fadeFactor);
        if (startCount > 99) { SceneManager.LoadScene(1); }
        else { StartCoroutine(fadeOut()); }

    }
}
