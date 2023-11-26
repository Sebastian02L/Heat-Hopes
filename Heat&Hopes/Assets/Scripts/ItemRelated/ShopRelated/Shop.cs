using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shop; //La tienda a desplegar
    [SerializeField] private GameObject confirmMenu; //Men� de confirmaci�n de compras
    [SerializeField] private GameObject returnMenu; //Men� de devoluci�n de compras
    [SerializeField] private GameObject advisoryText; //Texto de advertencia de compras / ventas
    [SerializeField] private GameObject confirmationButton; //Texto de advertencia de compras / ventas
    [SerializeField] private GameObject keyText; //Texto que recuerda qu� tecla debe ser pulsada para acceder a la tienda
    private PlayerController player; //Jugador
    private PauseMenu pauseMenu; //Men� de pausa
    private bool onShopRange = false; //Booleano que indica si el jugador se encuentra al lado del punto de acceso a la tienda para poder acceder a ella
    public bool confirmationEnabled;
    public AudioSource enterOutSound;
    private string language;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        pauseMenu = GameObject.Find("GUI").GetComponent<PauseMenu>();
        shop.SetActive(false);
        confirmMenu.SetActive(false);
        returnMenu.SetActive(false);
        advisoryText.SetActive(false);
        keyText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        language = LocalizationSettings.SelectedLocale.LocaleName;
        if (!pauseMenu.gameIsPaused)
        {
            if (onShopRange && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Keypad0))) ToggleAccessShop();
            if (onShopRange && pauseMenu.shopIsOpen && Input.GetKeyUp(KeyCode.Escape)) ToggleAccessShop(); //Tambi�n se puede cerrar la tienda con ESC
        }

        confirmationEnabled = pauseMenu.confirmationEnabled;
        if (confirmationEnabled)
        {
            if (language == "Spanish (es)") confirmationButton.GetComponentInChildren<TextMeshProUGUI>().text = "Desactivar confirmaciones";
            else confirmationButton.GetComponentInChildren<TextMeshProUGUI>().text = "Disable confirmations";
        }
        else
        {
            if (language == "Spanish (es)") confirmationButton.GetComponentInChildren<TextMeshProUGUI>().text = "Activar confirmaciones";
            else confirmationButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enable confirmations";
        }
    }

    public void ToggleAccessShop() //Funci�n que alterna la tienda: si el men� de la tienda est� cerrado lo abre y si est� abierto lo cierra
    {
        enterOutSound.Play();
        //Hay que parar el movimiento del jugador cuando se tenga ya su script
        if (advisoryText.activeSelf) advisoryText.SetActive(false);
        shop.SetActive(!shop.activeSelf);
        player.ToggleMovement(); //Impide el movimiento del jugador si la tienda est� abierta y lo permite si est� cerrada
        pauseMenu.shopIsOpen = !pauseMenu.shopIsOpen;
    }

    public void ToggleConfirmation() //Opci�n que habilita/deshabilita confirmaciones
    {
        pauseMenu.ToggleConfirmation();
    }

    public void ToggleEnableAccess() //Cuando se ha confirmado una acci�n el jugador puede volver a abrir la tienda
                                     //Si el jugador se encuentra en el men� de confirmaci�n y no se le restringe el acceso a tiendas
                                     //puede darle a la F y volver a abrirla
    {
        onShopRange = !onShopRange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) onShopRange = true;
        keyText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) onShopRange = false;
        keyText.SetActive(false);
    }
}
