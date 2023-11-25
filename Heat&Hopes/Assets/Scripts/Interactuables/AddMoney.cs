using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{

    public float value = 10f;
    private bool added = false;
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Player"))
        {
            if (added==false) { 
            Destroy(gameObject);
            Debug.Log("Dinero recogido");
            other.gameObject.GetComponentInChildren<PlayerInventoryManager>().AddMoney(value);
                added = !added;
            }
        }
    }

}
