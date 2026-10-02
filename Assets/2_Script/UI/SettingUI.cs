using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Slider vfxSlider;
    [SerializeField] private Slider bgmSlider;

    private void Start()
    {
        vfxSlider.value = VolumeSettings.VFXVolume;
        bgmSlider.value = VolumeSettings.BGMVolume;
    }
    
    private void Update()
    {
        if (vfxSlider.value != VolumeSettings.VFXVolume)
        {
            ChangeVFXVolume(vfxSlider.value);
        }
    }
    public void ChangeVFXVolume(float value)
    {
        VolumeSettings.VFXVolume = value;
        UISoundManager.Instance.SetVolume(value);

    }

    public void ChangeBGMVolume(float value)
    {
        VolumeSettings.BGMVolume = value;

    }
}
