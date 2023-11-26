using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCheckpoint : MonoBehaviour
{
    public AudioSource checkpointSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            checkpointSound.Play();
            other.gameObject.GetComponent<Checkspoints>().UpdateCheckpoints();
            Debug.Log("Nuevo checkpoint");
            transform.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
