using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBehaviourExample : MonoBehaviour
{
    public float lives = 10;
    public void TakeDamage(float damage) {
        lives -= damage;
        Debug.Log(lives);
        if (lives <= 0) {
        
            Debug.Log("Jugador muerto");
        }
    }
}
