using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline;
using UnityEngine;

public class TextContainer : MonoBehaviour
{
    //Lista con todos los textos del juego
    public List<GameObject> textList = new List<GameObject>();

    //Metodo que se llama desde TextConfiguration para guardar los textos en la lista
    //public void addToList(TextConfiguration textToAdd)
    //{
    //    textList.Add(textToAdd);
    //}

    //Metodo llamado desde DyslexiaControl para usar la lista actualizada
    public List<GameObject> getList() 
    {
        return textList;
    }
}
