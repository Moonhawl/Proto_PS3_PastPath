using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class demManager : MonoBehaviour
{
    public bool usingShovel;
    public bool usingDetect;

    public Vector3 offPos;
    public Vector3 onPos;

    public GameObject cursor;
    public GameObject[] objectifs;
    public GameObject[] Sands;
    public RectTransform lettre;
    public GameObject[] textes;

    int count;

    private void Start()
    {
        if (!Avancement.foundLetr) { Sands[1].SetActive(false); }
        else { Sands[0].SetActive(true);}
    }

    // Update is called once per frame
    void Update()
    {
        if(usingDetect || usingShovel)
        {
            //si au moins un doigt sur l'écran
            if(Input.touchCount > 0)
            {
                //récupéré la position du touché
                Vector2 targetPos = Input.GetTouch(0).position;

                //transformer la position dans la scène
                Vector3 positionMonde = Camera.main.ScreenToWorldPoint(new Vector3(targetPos.x, targetPos.y, 10f));

                cursor.transform.position = positionMonde;
            }
        }

        if (usingDetect)
        {
            //vibre avec la distance de l'objet Lettre ou mine
            Handheld.Vibrate();
        }
    }

    public void unearth(int wich)
    {
        if( usingShovel )
        {
            objectifs[wich].SetActive(true);
            Sands[wich].SetActive(false);
        }
    }

    public void foundMine()
    {
        
    }

    public void FoundLetter()
    {
        StartCoroutine(ShowLetter());
        Avancement.foundLetr = true;
    }

    public IEnumerator ShowLetter()
    {
        if(count < 500)
        {
            count++;
            lettre.position += Vector3.up * 2.5f;
            Debug.Log("CACA");
            yield return new WaitForSeconds(0.001f);
            StartCoroutine(ShowLetter());
        }
        else
        {
            StartCoroutine (flashBack());
        }
    }

    public IEnumerator flashBack()
    {
        text message = textes[Avancement.phase].GetComponent<text>();
        StartCoroutine(message.showLetterByLetter());
        yield return new WaitForSeconds(40);
        SceneManager.LoadScene(1);
    }
}
