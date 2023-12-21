using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options : MonoBehaviour
{
    public void fxSlider(float value)
    {
        Avancement.FxVol = value;
    }

    public void MusiqueSlider(float value)
    {
        Avancement.MusVol = value;
    }
}
