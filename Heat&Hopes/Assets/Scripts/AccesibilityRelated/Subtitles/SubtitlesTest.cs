using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitlesTest : MonoBehaviour
{
    public GameObject audioManager;
    private AudioSubtitlesManager subtitlesManager;

    private void Awake()
    {
        subtitlesManager = audioManager.GetComponent<AudioSubtitlesManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            subtitlesManager.setAudio(0);
        }
    }
}
