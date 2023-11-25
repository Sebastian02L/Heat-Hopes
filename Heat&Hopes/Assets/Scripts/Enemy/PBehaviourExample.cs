using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBehaviourExample : MonoBehaviour
{
    
    public void TakeDamage() {
     
        Debug.Log("Jugador muerto");
        gameObject.GetComponent<Checkspoints>().GoToCheckpoint();

    }
}
