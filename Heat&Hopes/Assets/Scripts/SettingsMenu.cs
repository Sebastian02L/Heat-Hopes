using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public PostProcessProfile brightness;
    public PostProcessLayer layer;

    private AutoExposure exposure;

    public void Start()
    {
        brightness.TryGetSettings(out exposure);
        exposure.keyValue.value = 1;
    }

    public void SetMasterVolume(float volume) //Función que recibe un float para modificar el canal Master del audioMixer con ese valor.
    {
        audioMixer.SetFloat("MasterVolume", volume); //Le asigna el valor del parámetro volume al parámetro volumeMaster del audioMixer.
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
        if (intensity != 0)
        {
            exposure.keyValue.value = intensity;
        }
        else
        {
            exposure.keyValue.value = .05f;
        }
    }
}