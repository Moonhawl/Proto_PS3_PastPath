using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Deminage : MonoBehaviour
{
    [SerializeField] int[] order;
    [SerializeField] int[] playerOrder = new int[9];
    [SerializeField] Image[] colorsButtons;
    [SerializeField] AudioSource fx;
    public Sprite[] onOff;
    public Color idlColor;
    public int Round = 3;

    public int count;
    int score;

    public bool turn;
    bool playing;

    [SerializeField] Slider stabilisatiometre;
    [SerializeField] TextMeshProUGUI countdown;
    public float baseTimer;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(chrono());
        for (int i = 0; i < order.Length; i++)
        {
            order[i] = Random.Range(0, 6);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //minigame
        if(!turn && !playing)
        {
            playing = true;
            StartCoroutine(PlayExample());
        }
        if(count == Round)
        {
            if(Round == 9)
            {
                //gg
                Avancement.phase++;
            }
            else
            {
                for(int i = 0; i < Round - 1; i++)
                {
                    if (order[i] == playerOrder[i]) { score++; }
                }
                if (score == Round-1) { Round += 2; }
                playerOrder = new int[9];
                score = 0; turn = false; count = 0;
            }
        }

        //get stability
        stabilisatiometre.value = Mathf.Lerp(stabilisatiometre.value, Input.acceleration.x,Time.deltaTime * 1);
    }

    public void playerTurn(int ID)
    {
        if(count < Round && turn)
        {
            playerOrder[count] = ID;
            count++;
            StartCoroutine(Flash(ID));
            fx.Play();
        }
    }

    public IEnumerator PlayExample()
    {
        for (int i = 0; i < Round; i++)
        {
            // color on
            yield return new WaitForSeconds(0.3f);
            colorsButtons[order[i]].sprite = onOff[1];

            //color off
            yield return new WaitForSeconds(0.4f);
            colorsButtons[order[i]].sprite = onOff[0];
            yield return null;
        }
        turn = true; playing = false;
        yield return null;
    }

    public IEnumerator Flash(int i)
    {
        // color on
        colorsButtons[i].sprite = onOff[1];

        //color off
        yield return new WaitForSeconds(0.4f);
        colorsButtons[i].sprite = onOff[0];
        yield return null;
    }

    public IEnumerator chrono()
    {
        float factor = stabilisatiometre.value;
        if(factor < 0) { factor = factor * -1;}
        baseTimer -= 0.01f * (Mathf.Round(factor*10) + 1);
        countdown.text = Mathf.Round(baseTimer).ToString();
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(chrono());
    }
}