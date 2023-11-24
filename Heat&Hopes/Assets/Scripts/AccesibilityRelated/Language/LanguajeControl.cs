using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguajeControl : MonoBehaviour
{
    private bool active = false;

    //Recibe el ID del idioma (0 ingles, 1 español)
    public void ChangeLocale(int localeID)
    {
        if (active)
        {
            return;
        }
        //Comienza una corutina para cambiar el idioma de forma concurrente
        StartCoroutine(SetLocale(localeID));
    }
    //Cambia el idioma del juego colocando el ID del idioma seleccionado como el Locale actual
    IEnumerator SetLocale(int localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        active = false;
    }
}
