using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class howmuch : MonoBehaviour
{
    public TextMeshProUGUI guess;

    public int gameTarget;
    public int PlayerTarget = 0;

    bool result;

    public void validate()
    {
        if(PlayerTarget == gameTarget)
        {
            result = true;
            Debug.Log("gagner");
        }
        else
        {
            result = false;
            Debug.Log("perdu");
        }

    }

    public void more()
    {
        PlayerTarget++;
        guess.text = PlayerTarget.ToString();
    }

    public void less()
    {
        PlayerTarget--;
        guess.text = PlayerTarget.ToString();
    }
}
