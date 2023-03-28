using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;


public class MuteAudio : MonoBehaviour
{
    // champ pour déclarer l'audio source
    private AudioSource source;

    private bool isMute;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    //fonction pour activer/désactiver le son
    public void ToggleMuteMusic()
    {
        if (!isMute)
        {
            isMute = true;
        }
        else
        {
            isMute = false;
        }
        PlayerPrefs.SetInt("mute audio", isMute ? 1 : 0);
        source.mute = isMute;
    }

    public void Mute()
    {
        isMute = (PlayerPrefs.GetInt("mute audio") !=0);
        source.mute = isMute;
    }
}
