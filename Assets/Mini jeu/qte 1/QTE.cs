using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{
    [SerializeField]bool phase = true; // button or sweep
    [SerializeField] UIFader[] fade;

    bool sweepPhase = true;
    public float sweeepScore;
    int rnd;

    public float score;
    float BOUUTON;

    [SerializeField] int buttonsTrack = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        fade[0].fadeIn();
        fade[1].fadeOut(); fade[2].fadeOut(); fade[3].fadeOut();

        rnd = Random.Range(100, 300);
    }

    public void scroll(float value)
    {
        if (phase)
        {
            if (sweepPhase)
            {
                if (value >= 0.90f) { sweepPhase = false; sweeepScore += 10; }
            }

            if (!sweepPhase)
            {
                if (value <= 0.10f) { sweepPhase = true; sweeepScore += 10; }
            }

            if(sweeepScore >= rnd)
            {
                score += sweeepScore;
                sweeepScore = 0;

                fade[0].fadeOut();
                fade[1].fadeIn(); 

                phase = false;
            }
        }
    }

    public void buttonA()
    {
        if (!phase && buttonsTrack <= 0)
        {
            buttonsTrack++;
            fade[2].fadeIn(); 
        }
    }
    public void buttonB()
    {
        if (!phase && buttonsTrack <= 1)
        {
            buttonsTrack++;
            fade[3].fadeIn();
        }
    }
    public void buttonC()
    {
        if (!phase && buttonsTrack <= 2)
        {
            buttonsTrack = 0;
            score += 600;

            fade[0].fadeIn();
            fade[1].fadeOut(); fade[2].fadeOut(); fade[3].fadeOut();

            phase = true;
        }
    }
}
