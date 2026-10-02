using UnityEngine;

public class VolumeSettings
{
    public static float VFXVolume
    {
        get { return PlayerPrefs.GetFloat("VFXVolume", 1f); }
        set
        {
            PlayerPrefs.SetFloat("VFXVolume", value);
            PlayerPrefs.Save();
        }
    }

    public static float BGMVolume
    {
        get { return PlayerPrefs.GetFloat("BGMVolume", 1f); }
        set
        {
            PlayerPrefs.SetFloat("BGMVolume", value);
            PlayerPrefs.Save();
        }
    }
}