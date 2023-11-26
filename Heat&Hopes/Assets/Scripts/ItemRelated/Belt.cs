using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : Item
{
    private static bool used = false;
    private static bool acquired = false;
    private PlayerController player;
    private PlayerInventoryManager inventory;
    private float rotationSpeed = 300;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        inventory = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerInventoryManager>();
    }

    private void Update()
    {
        hasBeenUsed = used;
        bought = acquired;
        if (isActive && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)) && player.canMove)
        {
            UseAbility();
        }
    }

    protected override void UseAbility()
    {
        //La habilidad del cinturón consume un cuarto de la energía máxima del jugador
        if(inventory.energy >= inventory.maxEnergy / 4)
        {
            used = true;
            inventory.UpdateEnergy(-inventory.maxEnergy / 4);
            StartCoroutine(FlipCharacter());
            Physics2D.gravity *= -1;
            Debug.Log($"Habilidad de {itemName} usada. Gravedad invertida.");
        }
    }

    public override void ItemBought(bool state)
    {
        acquired = state;
    }

    IEnumerator FlipCharacter()
    {
        player.transform.Rotate(new Vector3(0.0f, 0.0f, rotationSpeed)*Time.deltaTime);
        yield return new WaitForSeconds(0.001f);
        if (Physics2D.gravity.y > 0 && player.transform.rotation.z < 0)
        {
            player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            player.transform.localScale = new Vector3(-1, 1, 1); //Hay que rotar al jugador para que no camine hacia atrás
        } 
        else if (Physics2D.gravity.y < 0 && player.transform.rotation.z > 0)
        {
            player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            player.transform.localScale = new Vector3(1, 1, 1);
        }
        else StartCoroutine(FlipCharacter());
    }
}
