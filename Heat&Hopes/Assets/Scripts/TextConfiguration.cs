using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Componente que almacena la configuracion de los textos
public class TextConfiguration : MonoBehaviour
{
    //Variables de la clase
    private float characterSpacing;         
    private float fontSize;
    private float lineSpacing;
    private TextMeshProUGUI text;


    private void Awake()
    {
        //Se inicializan a cero el espaciado entre letras, palabras y lineas
        characterSpacing = 0;
        lineSpacing = 0;

        //Guardamos el componente TextMeshProUGUI y aplicamos los valores por defecto al texto
        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.characterSpacing = characterSpacing;
        text.lineSpacing = lineSpacing;

        //Agregamos la instancia a la lista de textos de la clase DyslexiaControl
        GameObject.Find("Canvas").GetComponent<DyslexiaControl>().addToList(this);
    }

    public void updateText(float character, float fontSize, float line)
    {
        //Actualizamos los atributos del texto con los parametros recibidos
        text.characterSpacing = character;
        text.fontSize = text.fontSize + fontSize;
        text.lineSpacing = line;
    }

}
