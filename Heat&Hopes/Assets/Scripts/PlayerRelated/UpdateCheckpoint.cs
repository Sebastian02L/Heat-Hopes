using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            other.gameObject.GetComponent<Checkspoints>().UpdateCheckpoints();
            Debug.Log("Nuevo checkpoint");
        }
    }
}
