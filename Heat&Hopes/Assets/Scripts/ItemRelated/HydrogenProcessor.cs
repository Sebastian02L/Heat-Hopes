using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrogenProcessor : Item
{
    private static bool used = false;
    private static bool acquired = false;

    private void Update()
    {
        hasBeenUsed = used;
        bought = acquired;
        if (isActive && (Input.GetKeyDown(KeyCode.Mouse0)))
        {
            //UseAbility();
        }
    }

    protected override void UseAbility()
    {
        used = true;
        Debug.Log($"Habilidad de {itemName} usada.");
    }

    public override void ItemBought(bool state)
    {
        acquired = state;
    }
}
