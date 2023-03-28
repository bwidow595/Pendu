using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    //Fields audiomixer
    [SerializeField]
    private AudioMixer audioMixer;

    // fonction pour parametrer le volume sonore
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
