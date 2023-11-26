using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDetection : MonoBehaviour
{
    private PlayerInventoryManager _inventoryManager;

    private void Start()
    {
        _inventoryManager = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerInventoryManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < _inventoryManager.items.Length; i++)
            {
                if (_inventoryManager.items[i]!=null)
                _inventoryManager.items[i].ChangeItemStatus();
            }

            SceneManager.LoadScene(2);
        }
    }
}
