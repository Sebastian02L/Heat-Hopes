using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Boots : Item
{
    private float _maxEnergy = 2f;
    private float _currEnergy;
    private float _thrustForce = 0.1f;

    private PlayerController _player;
    private Rigidbody2D _playerRigidBody;

    private bool _abilityKeyPressed = false;

    private static bool used = false;
    private static bool acquired = false;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _playerRigidBody = _player.GetComponent<Rigidbody2D>();
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

        if (isActive && _abilityKeyPressed && _currEnergy > 0 && _player.canMove)
        {
            used = true;

            _currEnergy -= Time.deltaTime;

            if (_currEnergy > 0.1)
            {
                _playerRigidBody.AddForce(_playerRigidBody.transform.up * _thrustForce, ForceMode2D.Impulse);
            }

            Debug.Log($"Habilidad de {itemName} en uso. Gastando energía...");
        }
        else if (_abilityKeyPressed && _currEnergy <= 0) 
        {
            _currEnergy = 0;
            Debug.Log("Sin energía");
        }

        if(_player.grounded == true) //Creo que esto no debería ir aquí ya que la energía se consigue explorando el mundo
        {
            if (_currEnergy < _maxEnergy)
            {
                _currEnergy += Time.deltaTime;
                Debug.Log("Recargando Energía");
            }
            else
            {
                _currEnergy = _maxEnergy;
                Debug.Log("Energía máxima alcanzada");
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
