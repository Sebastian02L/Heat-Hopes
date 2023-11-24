using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Boots : Item
{
    private float _maxEnergy = 2f;
    private float _currEnergy;
    private float _thrustForce = 0.1f;

    private PlayerController _player;
    private Rigidbody2D _playerRigidBody;
    private Slider _slider;

    private bool _abilityKeyPressed = false;

    private static bool used = false;
    private static bool acquired = false;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _playerRigidBody = _player.GetComponent<Rigidbody2D>();
        _slider = GameObject.Find("EnergyBar").GetComponent<Slider>();
    }

    private void Start()
    {
        _currEnergy = _maxEnergy;
        _slider.value = _currEnergy;
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
            _slider.value = _currEnergy;

            if (_currEnergy > 0.1)
            {
                _playerRigidBody.AddForce(_playerRigidBody.transform.up * _thrustForce, ForceMode2D.Impulse);
            }

            Debug.Log($"Habilidad de {itemName} en uso. Gastando energ�a...");
        }
        else if (_abilityKeyPressed && _currEnergy <= 0) 
        {
            _currEnergy = 0;
            _slider.value = _currEnergy;
            Debug.Log("Sin energ�a");
        }

        if(_player.grounded == true) //Creo que esto no deber�a ir aqu� ya que la energ�a se consigue explorando el mundo
        {
            if (_currEnergy < _maxEnergy)
            {
                _currEnergy += Time.deltaTime;
                _slider.value = _currEnergy;
                Debug.Log("Recargando Energ�a");
            }
            else
            {
                _currEnergy = _maxEnergy;
                _slider.value = _currEnergy;
                Debug.Log("Energ�a m�xima alcanzada");
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
