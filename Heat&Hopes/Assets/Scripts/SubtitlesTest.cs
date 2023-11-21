using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitlesTest : MonoBehaviour
{
    public AudioSource dialogAudio; //este script solo sirve para que se reproduzca el audio
    public GameObject audioManager;
    private AudioSubtitlesManager subtitlesManager;

    private void Awake()
    {
        subtitlesManager = audioManager.GetComponent<AudioSubtitlesManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            subtitlesManager.setAudio(0);
        }
    }
}
