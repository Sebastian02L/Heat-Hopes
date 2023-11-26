using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddMoney : MonoBehaviour
{

    public float value = 10f;
    private bool added = false;
    public AudioSource recolectSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        recolectSound.Play();
        if (other.CompareTag("Player"))
        {
            if (added==false) {

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("Dinero recogido");
            other.gameObject.GetComponentInChildren<PlayerInventoryManager>().AddMoney(value);
             added = !added;
                Destroy(gameObject, 3);
            }
        }
    }

}
