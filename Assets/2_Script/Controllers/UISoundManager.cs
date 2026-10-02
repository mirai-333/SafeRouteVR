using UnityEngine;

public class UISoundManager : MonoBehaviour
{
    public static UISoundManager Instance;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip appear;
    [SerializeField] private AudioClip appear2;
    [SerializeField] private AudioClip correct;
    [SerializeField] private AudioClip wrong;
    [SerializeField] private AudioClip arrived;
    [SerializeField] private AudioClip ting2;
    [SerializeField] private AudioClip pickup;
    [SerializeField] private AudioClip backpack;
    [SerializeField] private AudioClip wave;


    
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void PlayButton()
    {
        audioSource.PlayOneShot(buttonClick, VolumeSettings.VFXVolume);
    }

    public void PlayAppear()
    {
        audioSource.PlayOneShot(appear, VolumeSettings.VFXVolume);
    }

    public void PlayAppear2()
    {
        audioSource.PlayOneShot(appear2, VolumeSettings.VFXVolume);
    }

    public void PlayCorrect()
    {
        audioSource.PlayOneShot(correct, VolumeSettings.VFXVolume);
    }

    public void PlayWrong()
    {
        audioSource.PlayOneShot(wrong, VolumeSettings.VFXVolume);
    }

    public void PlayArrow()
    {
        audioSource.PlayOneShot(arrived, VolumeSettings.VFXVolume);
    }

    public void PlayTing2()
    {
        audioSource.PlayOneShot(ting2, VolumeSettings.VFXVolume);
    }

    public void PlayPickup()
    {
        audioSource.PlayOneShot(pickup, VolumeSettings.VFXVolume);
    }

    public void PlayBackpack()
    {
        audioSource.PlayOneShot(backpack, VolumeSettings.VFXVolume);
    }

    public void PlayWave()
    {
        audioSource.PlayOneShot(wave, VolumeSettings.VFXVolume);
    }
}
