using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitlesTest : MonoBehaviour
{
    //Referencia al maganer del sistema de subtitulos y dialogos
    public GameObject audioManager;

    //Variable publica para definir desde el editor que audio debe reproducirse al chocar con el collider del trigger
    public int dialogNumber;

    //variable donde se guardará el componente AudioSubtitleManager del Sistema
    private AudioSubtitlesManager subtitlesManager;

    private void Awake()
    {
        subtitlesManager = audioManager.GetComponent<AudioSubtitlesManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Activa los audios correspondientes
        subtitlesManager.setAudio(dialogNumber);

        //Desactivamos el collider para que no se repita el dialogo al volver a entrar en el collider
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
