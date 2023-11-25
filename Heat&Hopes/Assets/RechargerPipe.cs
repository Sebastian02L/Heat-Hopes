using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargerPipe : MonoBehaviour
{
    private PlayerInventoryManager _inventoryManager;
    public bool recharging = false;

    // Start is called before the first frame update
    void Start()
    {
        _inventoryManager = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerInventoryManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Entering collision pipe area...");
            recharging = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Leaving collision pipe area...");
            recharging = false;
        }
    }
}
