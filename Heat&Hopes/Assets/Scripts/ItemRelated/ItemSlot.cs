using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private Item item;
    [SerializeField] private Image image;
    private PlayerInventoryManager inventory;
    public int index; //Elemento del array de ítems que muestra este slot

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerInventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        item = inventory.items[index];
        if(item != null)
        {
            image.sprite = item.image;
            if (item.isActive)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0.3f);
            }
            else
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
            }
        }
        else
        {
            image.sprite = null;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
        }
    }
}
