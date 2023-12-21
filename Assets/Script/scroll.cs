using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scroll : MonoBehaviour
{
    float pos;
    public GameObject cam;
    public float maxDist;
    float move;

    public void goLeft()
    {
        if(pos > -maxDist)
        {
            move -= 0.1f;
            pos -- ;
        }
        
    }

    public void goRight()
    {
        if (pos < maxDist)
        {
            move += 0.1f;
            pos ++ ;
        }
    }

    private void Update()
    {
        cam.transform.position += new Vector3(move, 0, 0);
        move = Mathf.Lerp(move, 0, 0.02f);
        //move = Mathf.Round(move) *0.1f;
    }
}
