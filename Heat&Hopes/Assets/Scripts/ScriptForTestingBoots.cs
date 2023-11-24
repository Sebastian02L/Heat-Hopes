using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class ScriptForTestingBoots : MonoBehaviour
{
    private float _maxEnergy = 4f;
    public float _currEnergy;
    private float _thrustForce = 0.1f;

    private Rigidbody2D _playerRigidBody;
    private PlayerController _playerController;
    private PauseMenu _pauseMenu;

    private bool _abilityKeyPressed = false;

    private void Awake()
    {
        _playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _pauseMenu = GameObject.Find("Canvas").GetComponent<PauseMenu>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _currEnergy = _maxEnergy;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_pauseMenu.gameIsPaused) {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _abilityKeyPressed = true;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _abilityKeyPressed = false;
            }

            if (_abilityKeyPressed && _currEnergy > 0)
            {
                _currEnergy -= Time.deltaTime;

                if (_currEnergy > 0.1)
                {
                    _playerRigidBody.AddForce(_playerRigidBody.transform.up * _thrustForce, ForceMode2D.Impulse);
                }

                Debug.Log("Habilidad en uso. Gastando energía...");
            }
            else if (_abilityKeyPressed && _currEnergy <= 0)
            {
                _currEnergy = 0;
                Debug.Log("Sin energía");
            }

            if (_playerController.grounded == true)
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
    }
}
