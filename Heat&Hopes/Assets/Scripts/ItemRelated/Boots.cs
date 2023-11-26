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
    private ParticleSystem _playerParticleSystem;
    private ParticleSystem.EmissionModule _playerParticleSystemEmission;

    private bool _abilityKeyPressed = false;

    private static bool used = false;
    private static bool acquired = false;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _inventory = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerInventoryManager>();
        _playerRigidBody = _player.GetComponent<Rigidbody2D>();
        _pauseMenu = GameObject.Find("GUI").GetComponent<PauseMenu>();
        _playerParticleSystem = GameObject.FindWithTag("Player").GetComponentInChildren<ParticleSystem>();
        _playerParticleSystemEmission = _playerParticleSystem.emission;
        spanishName = "Botas propulsadas";
        spanishDescription = "Unas botas con las que se puede saltar más alto a cambio de un poco de hidrógeno verde sin procesar.";
        englishName = "Powered boots";
        englishDescription = "A pair of boots that allow the user to jump higher using fuel.";
    }
    
    private void Update()
    {
        hasBeenUsed = used;
        bought = acquired;

        if (!_pauseMenu.gameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
            {
                _abilityKeyPressed = true;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Mouse1))
            {
                _abilityKeyPressed = false;
            }
        }

        if(_inventory.energy == 0 || Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Mouse1))
        {
            _playerParticleSystemEmission.enabled = false;
        }
        CheckLanguage();
    }

    private void FixedUpdate()
    {
        if (isActive && _abilityKeyPressed && _inventory.energy > 0 && _player.canMove)
        {
            UseAbility();
        }
    }

    protected override void UseAbility()
    {
        used = true;

        _inventory.UpdateEnergy(-Time.fixedDeltaTime);

        _playerParticleSystemEmission.enabled = true;
        _playerRigidBody.AddForce(_playerRigidBody.transform.up * _thrustForce, ForceMode2D.Impulse);

        Debug.Log($"Habilidad de {itemName} en uso. Gastando energía...");
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
