using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeLevel : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    private void Start()
    {
        for(int i  = 0; i < buttons.Length; i++)
        {
            if(Avancement.phase > i)
            {
                buttons[i].enabled = false;
            }
            else if(Avancement.phase == i)
            {
                buttons[i].enabled = true;
            }
            else // phase not reach yet
            {
                buttons[i].enabled = false;
            }
        }
    }

    public void sceneSelect(int wich)
    {
        SceneManager.LoadScene(wich);
        Avancement.phase ++;
    }
}
