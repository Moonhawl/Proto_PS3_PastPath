using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comptage : MonoBehaviour
{
    int count = 0;
    [SerializeField] UIFader[] fade;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< fade.Length; i++)
        {
            fade[i].Disapear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(count == 5) { Debug.Log("GG"); }
    }

    public void truc(GameObject self)
    {
        count++;
        Button but = self.GetComponent<Button>();
        but.enabled = false;

        CanvasGroup Cg = self.GetComponent<CanvasGroup>();
        Cg.alpha = 1;
    }
}
