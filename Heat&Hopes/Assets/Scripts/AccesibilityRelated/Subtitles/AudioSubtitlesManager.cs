using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

//Encargada de reproducir los audios y de mostar los subtitulos
public class AudioSubtitlesManager : MonoBehaviour
{
    //Referencia al audio source
    public AudioSource subtitlesAudioSource;

    //Listas con los audios en ambos idiomas
    public List<AudioClip> spanishAudioSources;
    public List<AudioClip> englishAudioSources;

    //Listas con los subtitulos en varios idiomas
    public List<string> spanishSubstitleText;
    public List<string> englishSubstitleText;

    //Referencia al cuadro de texto donde se desplegaran los subtitulos
    public TextMeshProUGUI subtitlesBox;

    //Variable donde guardaremos el valor del Locale que define el idioma seleccionado
    private string actualLanguage;

    //Metodo que recibe la key del audio que debe poner, es importante que coincidan para ambos idiomas
    public void setAudio(int key)
    {
        //Actualizamos la variable para confirmar el idioma seleccionado
        actualLanguage = LocalizationSettings.SelectedLocale.LocaleName;

        if (actualLanguage == "Spanish (es)")         //si el idioma seleccionado es español
        {
            subtitlesAudioSource.clip = spanishAudioSources[key];

        } else if(actualLanguage == "English (en)")   //si el idioma seleccionado es ingles
        {
            subtitlesAudioSource.clip = englishAudioSources[key];
        }

        showSubtitle(key);
        subtitlesAudioSource.Play();
    }

    //Metodo encargado mostrar por pantalla los subtitulos correspondientes al audio reproducido
    public void showSubtitle(int key)
    {
        if (actualLanguage == "Spanish (es)")         //si el idioma seleccionado es español
        {
            subtitlesBox.text = spanishSubstitleText[key];

        }
        else if (actualLanguage == "English (en)")   //si el idioma seleccionado es ingles
        {
            subtitlesBox.text = englishSubstitleText[key];
        }
    }

    //Si no hay ningún audio reproduciendose, se elimina el texto
    private void Update()
    {
        if (!subtitlesAudioSource.isPlaying)
        {
            subtitlesBox.text = "";
        }
    }
}

/////////////////////////////////////////////// Observaciones /////////////////////////////////////////////// 
// Funcionamiento: Al darle a jugar, pulsa "0" para que se reproduzca el audio de prueba, si cambias el idioma
// (que se puede hacer si pulsas el recuadro que te sale arriba a la derecha y seleccionas el idioma) cambiará el
//audio y los subtitulos correspondientes. ESTE COMPORTAMIENTO ES SOLO PARA PROBARLO, EN EL JUEGO FUNCIONARÁ DISTINTO
//
//El GameObject "SubtitlesAudioManager" tiene asociado este script y en la jerarquia tiene como hijo el AudioSource, que
//reproduce el audio. El script tiene unas listas donde se almacenan los audios y los subtitulos en ingles y español
//(todos tienen en comun su posicion en las listas, de manera que se reproduzca y muestre todo de forma correcta)
//
// 1. Todavia no está diseñado el soporte para audios más largos donde debes ir cambiando los subtitulos
// 2. Todavia no compatible con los ajustes de idioma y texto, se hará cuando todas las interfaces estén en una sola escena