using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



//Clase encargada de permitir la configuracion de la fuente por parte del usuario
public class DyslexiaControl : MonoBehaviour
{
    //Variables de la Clase

    //variable que almacena el texto de ejemplo del menu
    private TextMeshProUGUI text;
    float fontSize;

    //Lista con todos los textos del juego
    private List<TextConfiguration> textList = new List<TextConfiguration>();   
 
    private void Awake()
    {
        //Inicializamos la variable text con el componente TextMeshProUGUI
        GameObject go = GameObject.Find("TestText");
        text = go.GetComponent<TextMeshProUGUI>();
    }

    //En funcion del valor recibido por el Slider, se seleccionara un modo de distancia entre letras
    public void changeLetterDistance(float sliderFloat)
    {
        switch (sliderFloat)
        {
            case 0:
                text.characterSpacing = sliderFloat;
                break;
            case 1:
                text.characterSpacing = sliderFloat + 2;
                break;
            case 2:
                text.characterSpacing = sliderFloat + 4;
                break;
            case 3:
                text.characterSpacing = sliderFloat + 6;
                break;
            case 4:
                text.characterSpacing = sliderFloat + 6;
                break;
            case 5:
                text.characterSpacing = sliderFloat + 7;
                break;
        }
    }

    //En funcion del valor recibido por el Slider, se seleccionara un modo de tama�o de letra. FALTA ARREGLARLO
    public void changeFontSize(float sliderFloat)
    {
        if(sliderFloat < fontSize)
        {
            fontSize = sliderFloat - fontSize;
        }
        fontSize = sliderFloat;

        text.fontSize = text.fontSize + fontSize;
    }

    //En funcion del valor recibido por el Slider, se seleccionara un modo de distancia entre lineas
    public void changeLineDistance(float sliderFloat)
    {
        switch (sliderFloat)
        {
            case 0:
                text.lineSpacing = sliderFloat;
                break;
            case 1:
                text.lineSpacing = sliderFloat + 2;
                break;
            case 2:
                text.lineSpacing = sliderFloat + 4;
                break;
            case 3:
                text.lineSpacing = sliderFloat + 6;
                break;
            case 4:
                text.lineSpacing = sliderFloat + 6;
                break;
            case 5:
                text.lineSpacing = sliderFloat + 7;
                break;
        }
    }

    public void addToList(TextConfiguration textToAdd)
    {
        textList.Add(textToAdd);
    }

    //Confirma los cambios hechos por el usuario recorriendo la lista de textos y actualizando sus atributos
    public void confirmChanges()
    {
        foreach(TextConfiguration textConfiguration in textList)
        {
            textConfiguration.updateText(text.characterSpacing, fontSize, text.lineSpacing);
        }
    }
}
