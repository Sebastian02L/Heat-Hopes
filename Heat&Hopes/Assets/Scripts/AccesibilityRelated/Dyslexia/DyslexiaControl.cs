using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



//Clase encargada de permitir la configuracion de la fuente por parte del usuario
public class DyslexiaControl : MonoBehaviour
{
    //Variables de la Clase

    //variable que almacena el texto de ejemplo del menu
    private TextMeshProUGUI text;

    //Variables auxiliares para el manejo del cambio de el tama�o de la letra
    private float fontSizeChange = 0;       //Almacena el numero que debera sumarse a la fuente de todos los textos al pulsar "Confirmar"
    private float minFontTestText = 22;     //Almacena el valor minimo para el texto de referencia
    private float maxFontTestText = 28;     //Almacena el valor m�ximo para el texto de referencia
    List<GameObject> textList;
    public GameObject textContainer;
 
    private void Awake()
    {
        //Inicializamos la variable text con el componente TextMeshProUGUI
        Transform go = transform.Find("TestText");
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
                text.characterSpacing = sliderFloat + 1;
                break;
            case 2:
                text.characterSpacing = sliderFloat + 2;
                break;
            case 3:
                text.characterSpacing = sliderFloat + 3;
                break;
            case 4:
                text.characterSpacing = sliderFloat + 4;
                break;
            case 5:
                text.characterSpacing = sliderFloat + 5;
                break;
        }
    }

    //Al pulsar el boton Aa+, aumenta en 1 el tama�o de la fuente de referencia. El tope es el valor 28
    public void changeFontSizeBigger(float buttomFloat)
    {
        if(text.fontSize == 28)
        {
            text.fontSize += 0;
        }
        else
        {
            text.fontSize += buttomFloat;
            fontSizeChange++;
        }
    }
    //Al pulsar el boton Aa-, disminuye en 1 el tama�o de la fuente de referencia. El tope es el valor 20
    public void changeFontSizeSmaller(float buttomFloat)
    {
        if (text.fontSize == 22)
        {
            text.fontSize += 0;
        }
        else
        {
            text.fontSize += buttomFloat;
            fontSizeChange--;
        }
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
                text.lineSpacing = sliderFloat + 1;
                break;
            case 2:
                text.lineSpacing = sliderFloat + 2;
                break;
            case 3:
                text.lineSpacing = sliderFloat + 3;
                break;
            case 4:
                text.lineSpacing = sliderFloat + 4;
                break;
            case 5:
                text.lineSpacing = sliderFloat + 5;
                break;
        }
    }

    //Confirma los cambios hechos por el usuario recorriendo la lista de textos y actualizando sus atributos
    public void confirmChanges()
    {
        //Lista auxiliar que recibe la lista de textos
        if (textList == null)
        {
            textList = textContainer.GetComponent<TextContainer>().getList();
        }

        foreach(GameObject textConfiguration in textList)
        {
            textConfiguration.GetComponent<TextConfiguration>().updateText(text.characterSpacing, fontSizeChange, text.lineSpacing);
        }
        //El tama�o del texto de referencia se pasar� de sus limites luego de esta llamada (porque se aplica dos veces), por lo tanto
        //Si el tama�o del texto es < 20, asignamos su valor m�nimo, para que no se pueda seguir reduciendo su tama�o
        if(text.fontSize < 22)
        {
            text.fontSize = minFontTestText;
        } 
        //Si en cambio, el tama�o es > 28, asignamos su valor m�ximo, para que no se pueda seguir aumentando
        else if (text.fontSize > 28)
        {
            text.fontSize = maxFontTestText;
        } 
        //Reiniciamos la variable a 0 y liberamos la lista auxiliar
        fontSizeChange = 0;
    }
}
