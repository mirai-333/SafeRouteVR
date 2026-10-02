using UnityEngine;

public class VFXvolume : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = VolumeSettings.VFXVolume;
    }

}
