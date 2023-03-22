using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static Unity.VisualScripting.Member;

public class SettingMenu : MonoBehaviour
{
    //Fields audiomixer
    public AudioMixer audioMixer;

    // fonction pour parametrer le volume sonore
    public void SetVolume(float volume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
}
