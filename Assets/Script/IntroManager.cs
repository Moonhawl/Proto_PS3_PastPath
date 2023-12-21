using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private text[] textes;
    [SerializeField] private cinematiqueManager cinMange;

    [Header("Stats")]
    public int howManyNext;
    int next;

    int phase = 0;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(textes[0].showLetterByLetter());
    }

    public void nextText()
    {
        next++;
        if (next >= howManyNext)
        {
            cinMange.fadeExit();
            phase++;
        }
        else
        {
            //clear old
            textes[phase].fadeAway();

            //read new
            StartCoroutine(textes[phase].showLetterByLetter());
        }

    }
}
