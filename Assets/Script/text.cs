using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text : MonoBehaviour
{

    string originalTexte;
    [SerializeField]TextMeshProUGUI uitext;
    public float delai = 0.2f;
    CanvasGroup fade;
    bool fading = false;


    private void Awake()
    {
        uitext = GetComponent<TextMeshProUGUI>();
        gameObject.AddComponent<CanvasGroup>();
        fade = GetComponent<CanvasGroup>();
        originalTexte = uitext.text;
        uitext.text = null;
    }

    private void Update()
    {
        if (fading)
        {
            fade.alpha -= 0.03f;
        }
    }
    public IEnumerator showLetterByLetter()
    {
        gameObject.SetActive(true);
        for (int i = 0; i <originalTexte.Length; i++)
        {
            uitext.text = originalTexte.Substring(0,i);
            yield return new WaitForSeconds(delai);
        }
    }

    public void fadeAway()
    {
        fading = true;
    }

}
