using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    //public Volume volume;

    public void SetMasterVolume(float volume) //Funci�n que recibe un float para modificar el canal Master del audioMixer con ese valor.
    {
        audioMixer.SetFloat("MasterVolume", volume); //Le asigna el valor del par�metro volume al par�metro volumeMaster del audioMixer.
    }

    //Las siguientes dos funciones funcionan de forma equivalente.

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSoundEffectsVolume(float volume)
    {
        audioMixer.SetFloat("SoundEffectsVolume", volume);
    }

    public void SetBrightnessIntensity(float intensity)
    {
        //ColorAdjustments colorAdjustments;
        //if(volume.profile.TryGet(out colorAdjustments))
        //{
        //    colorAdjustments.postExposure.value = intensity;
        //}
    }
}
