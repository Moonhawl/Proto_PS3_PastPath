using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cinematique : MonoBehaviour
{
    public GameObject[] images;
    public int sceneAmmount;

    int count;

    public void next()
    {
        if (count < sceneAmmount)
        {
            count++;
            images[count].SetActive(true);
            images[count-1].SetActive(false);

        }
        else
        {
            SceneManager.LoadScene(Avancement.phase+4);
        }
    }
}
