using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jaugeScript : MonoBehaviour
{
    public Slider Bar;
    public Slider objectif;
    public float target;
    public float transitionSpeed;
    public float graceValue;
    public float CheckFor;


    int count;


    private void Awake()
    {
       objectif.maxValue = Bar.maxValue;
    }

    private void Start()
    {
        newTarget();
    }

    public void more()
    {
        target++;
    }

    public void less()
    {
        target--;
    }

    private void Update()
    {
        if(target < 0) { target = 0; }
        if(target > Bar.maxValue) { target = Bar.maxValue; }
        Bar.value = Mathf.Lerp(Bar.value , target, Time.deltaTime*transitionSpeed);

        if(Bar.value >= objectif.value - graceValue && Bar.value <= objectif.value + graceValue)
        {
            newTarget();
        }

        Debug.Log(Bar.value >= objectif.value - graceValue && Bar.value <= objectif.value + graceValue);
    }

    public void newTarget()
    {
        objectif.value = Mathf.Round( Random.Range(1, objectif.maxValue - 1)) ;
        Debug.Log("New target :" + objectif.value + "\nGrace value :" + (objectif.value - graceValue) + " / " +(objectif.value + graceValue));

    }
}
