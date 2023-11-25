using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Boots : Item
{
    private float _thrustForce = 1f;
    private PlayerController _player;
    private PlayerInventoryManager _inventory;
    private Rigidbody2D _playerRigidBody;
    private PauseMenu _pauseMenu;

    private bool _abilityKeyPressed = false;

    private static bool used = false;
    private static bool acquired = false;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _inventory = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerInventoryManager>();
        _playerRigidBody = _player.GetComponent<Rigidbody2D>();
        _pauseMenu = GameObject.Find("GUI").GetComponent<PauseMenu>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        hasBeenUsed = used;
        bought = acquired;

        if (!_pauseMenu.gameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _abilityKeyPressed = true;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _abilityKeyPressed = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isActive && _abilityKeyPressed && _inventory.energy > 0 && _player.canMove)
        {
            used = true;

            _inventory.UpdateEnergy(-Time.fixedDeltaTime);

            if (_inventory.energy > 0.1) //Pequeña décima para que no empiece a volar directamente desde el suelo
            {
                _playerRigidBody.AddForce(_playerRigidBody.transform.up * _thrustForce, ForceMode2D.Impulse);
            }

            Debug.Log($"Habilidad de {itemName} en uso. Gastando energía...");
        }

        if (_player.grounded == true) //Creo que esto no debería ir aquí ya que la energía se consigue explorando el mundo
        {
            _inventory.UpdateEnergy(Time.fixedDeltaTime);
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
