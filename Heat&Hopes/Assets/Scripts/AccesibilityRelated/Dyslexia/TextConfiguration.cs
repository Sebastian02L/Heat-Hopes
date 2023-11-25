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
    private float lineSpacing;
    private TextMeshProUGUI text;
    private TextMeshPro text2;


    private void Start()
    {
        //Se inicializan a cero el espaciado entre letras, palabras y lineas
        characterSpacing = 0;
        lineSpacing = 0;

        //Guardamos el componente TextMeshProUGUI o TextMeshPro y aplicamos los valores por defecto al texto

        text = gameObject.GetComponent<TextMeshProUGUI>();
        text2 = gameObject.GetComponent<TextMeshPro>();

        if (text != null)
        {
            text.characterSpacing = characterSpacing;
            text.lineSpacing = lineSpacing;
        }
        else
        {
            text2.characterSpacing = characterSpacing;
            text2.lineSpacing = lineSpacing;
        }

    }

    public void updateText(float character, float fontSizeChange, float line)
    {
        if (text == null)
        {
            text = gameObject.GetComponent<TextMeshProUGUI>();

            //Si text sigue siendo nulo, quiere decir que no tiene TextMeshProGUI, entonces tendrá un TextMeshPro
            if (text == null)
            {
                text2 = gameObject.GetComponent<TextMeshPro>();
            }
        }
        //Actualizamos los atributos del texto con los parametros recibidos
        if (text != null)
        {
            text.characterSpacing = character;
            text.fontSize += fontSizeChange;
            text.lineSpacing = line;
        }
        else
        {
            text2.characterSpacing = character;
            text2.fontSize += (fontSizeChange / 16);
            text2.lineSpacing = line;
        }
    }

}