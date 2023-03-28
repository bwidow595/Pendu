using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager2 : MonoBehaviour
{
    public static AudioManager2 instance;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private VolumeSetting volumeSetting;

    public const string MUSIC_KEY = "musicVolume";

    private void Awake()
    {
        volumeSetting = GetComponent<VolumeSetting>();
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
