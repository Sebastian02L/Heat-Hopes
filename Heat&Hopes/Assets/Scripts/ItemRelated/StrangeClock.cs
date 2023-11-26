using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangeClock : Item
{
    private static bool used = false;
    private static bool acquired = false;

    private void Awake()
    {
        spanishName = "Reloj misterioso";
        spanishDescription = "Un misterioso reloj. ¿Para qué servirá?";
        englishName = "Uncanny clock";
        englishDescription = "A strange clock. What will it be used for?";
    }

    private void Update()
    {
        hasBeenUsed = used;
        bought = acquired;
        if (isActive && (Input.GetKeyDown(KeyCode.Mouse0)))
        {
            //UseAbility();
        }
        CheckLanguage();
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

    public override void ChangeItemStatus()
    {
        used = false;
        acquired = false;
    }
}
