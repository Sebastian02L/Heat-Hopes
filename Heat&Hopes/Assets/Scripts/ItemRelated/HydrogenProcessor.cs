using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrogenProcessor : Item
{
    private static bool used = false;
    private static bool acquired = false;

    private void Awake()
    {
        spanishName = "Procesador de hidrógeno";
        spanishDescription = "Mientras está activo convierte lentamente hidrógeno sin procesar en hidrógeno procesado.";
        englishName = "Hydrogen Processor";
        englishDescription = "Will convert raw hydrogen to processed hydrogen while active.";
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
}
