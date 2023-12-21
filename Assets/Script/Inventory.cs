using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private RectTransform pelle;
    [SerializeField] private RectTransform detect;
    [SerializeField] demManager manager;

    public float dist;
    bool open;
    bool moving;

    int count;

    public void OnTrigger()
    {
        if (!moving)
        {
            moving = true;
            count = 0;
            if (open) { open = false; StartCoroutine(InvOut()); }
            else { open = true; StartCoroutine(InvIn()); }
        }
    }

    public void useShovel()
    {
        manager.usingShovel = true;
        manager.usingDetect = false;
    }

    public void useDetect()
    {
        manager.usingShovel = false;
        manager.usingDetect = true;
    }

    public IEnumerator InvOut()
    {
        count ++;
        if(count >= 100)
        {
            moving = false;
            yield return null;
        }
        else
        {
            pelle.position -= new Vector3(1f, 0, 0);
            detect.position -= new Vector3(2f, 0, 0);
            yield return new WaitForSeconds(dist);
            StartCoroutine(InvOut());
        }
    }

    public IEnumerator InvIn()
    {
        count++;
        if (count >= 100)
        {
            moving = false;
            yield return null;
        }
        else
        {
            pelle.position += new Vector3(1.5f, 0, 0);
            detect.position += new Vector3(3f, 0, 0);
            yield return new WaitForSeconds(dist);
            StartCoroutine(InvIn());
        }
    }
}
