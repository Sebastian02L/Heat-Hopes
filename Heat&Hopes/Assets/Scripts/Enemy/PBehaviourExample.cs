using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBehaviourExample : MonoBehaviour
{
    public AudioSource playerDeath;

    public void TakeDamage() {
     
        playerDeath.Play();
        Debug.Log("Jugador muerto");

        gameObject.GetComponent<Checkspoints>().GoToCheckpoint();
    }
}
