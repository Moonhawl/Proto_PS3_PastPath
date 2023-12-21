using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class click : MonoBehaviour
{
    AudioSource source;
    public List<AudioClip> clics = new List<AudioClip>();

    void Awake()
    {
        //get audio source
        source = gameObject.AddComponent<AudioSource>();
        source.loop = false;
        source.volume = 0.7f;

        //get sounds
        string cheminDossier = "Son/fx/";

        for (int i = 1; i <= 4; i++)
        {
            string nomAudio = "Clic_" + i.ToString();
            AudioClip audioClip = Resources.Load<AudioClip>(cheminDossier + nomAudio);

            if (audioClip != null)
            {
                clics.Add(audioClip);
            }
            else
            {
                Debug.LogError("Audio Clip not found: " + nomAudio+1);
            }
        }
    }

    public void ClickFX()
    {
        source.clip = clics[Random.Range(0,clics.Count-1)];
        source.pitch = Random.Range(0.8f,1.2f);
        source.Play();
    }

    private void Update()
    {
        source.volume = Avancement.FxVol;
    }
}
