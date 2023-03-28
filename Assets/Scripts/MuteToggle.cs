using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MuteToggle : MonoBehaviour
{
    [SerializeField] private Toggle muteToggle;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (muteToggle != null)
        {
            bool isMute = (PlayerPrefs.GetInt("mute audio") != 0);
            muteToggle.isOn = isMute;
            Debug.Log(PlayerPrefs.GetInt("mute audio") != 0);
        }
    }
}
