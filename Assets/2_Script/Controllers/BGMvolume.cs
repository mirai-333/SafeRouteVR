using UnityEngine;

public class BGMvolume : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = VolumeSettings.BGMVolume;

    }

}
