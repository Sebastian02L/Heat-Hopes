using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Boots : Item
{
    private float _maxEnergy = 4f;
    private float _currEnergy;
    private float _thrustForce = 0.5f;

    private Rigidbody2D _playerRigidBody;

    private bool _abilityKeyPressed = false;

    private static bool used = false;
    private static bool acquired = false;

    private void Awake()
    {
        _playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _currEnergy = _maxEnergy;
    }

    private void Update()
    {
        hasBeenUsed = used;
        bought = acquired;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _abilityKeyPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _abilityKeyPressed = false;
        }

        if (isActive && _abilityKeyPressed && _currEnergy > 0)
        {
            used = true;

            _currEnergy -= Time.deltaTime;
            _playerRigidBody.AddForce(_playerRigidBody.transform.up * _thrustForce, ForceMode2D.Impulse);

            Debug.Log($"Habilidad de {itemName} usada.");
        }
        else
        {
            if (_currEnergy < _maxEnergy)
            {
                _currEnergy += Time.deltaTime;
            }
        }
    }

    protected override void UseAbility()
    {
        
    }

    public override void ItemBought(bool state)
    {
        acquired = state;
    }
}
