using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Boots : Item
{
    private float _maxEnergy = 4f;
    private float _currEnergy;
    private float _thrustForce = 0.5f;

    //public Rigidbody rigidBody;

    private static bool used = false;
    private static bool acquired = false;

    private void Start()
    {
        _currEnergy = _maxEnergy;
    }

    private void Update()
    {
        hasBeenUsed = used;
        bought = acquired;
        if (isActive && (Input.GetKeyDown(KeyCode.Mouse0)) && _currEnergy > 0)
        {
            UseAbility();
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
