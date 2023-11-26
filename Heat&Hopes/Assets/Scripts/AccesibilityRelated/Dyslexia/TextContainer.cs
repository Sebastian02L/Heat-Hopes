using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextContainer : MonoBehaviour
{
    //Lista con todos los textos del juego
    public List<GameObject> textList = new List<GameObject>();

    //Metodo llamado desde DyslexiaControl para usar la lista actualizada
    public List<GameObject> getList() 
    {
        return textList;
    }
}
