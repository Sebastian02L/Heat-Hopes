using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargerPipe : MonoBehaviour
{
    private PlayerInventoryManager _inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        _inventoryManager = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerInventoryManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Recharging energy...");
            _inventoryManager.UpdateEnergy(Time.fixedDeltaTime);
        }
    }
}
