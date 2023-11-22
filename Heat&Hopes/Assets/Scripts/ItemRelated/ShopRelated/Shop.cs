using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shop; //La tienda a desplegar
    [SerializeField] private GameObject confirmMenu; //Men� de confirmaci�n de compras
    [SerializeField] private GameObject returnMenu; //Men� de devoluci�n de compras
    [SerializeField] private GameObject advisoryText; //Texto de advertencia de compras / ventas
    [SerializeField] private GameObject confirmationButton; //Texto de advertencia de compras / ventas
    [SerializeField] private GameObject keyText; //Texto que recuerda qu� tecla debe ser pulsada para acceder a la tienda
    private bool canEnterShop = false; //Booleano que indica si el jugador se encuentra al lado del punto de acceso a la tienda para poder acceder a ella
    private bool shopIsOpen = false; //Booleano que indica si la tienda se encuentra desplegada o no
                                     //ShopIsOpen deber�a ser un booleano del men� de pausa, y se deber�a acceder a �l desde este script
                                     //para alterar su valor y que no se pueda pausar el juego si se le da a ESC

    public bool confirmationEnabled = true; //Booleano que el jugador podr� alterar desactivando o activando las confirmaciones.
                                            //No debe ir en este script, pero se programa la funcionalidad contando con �l.
    
    // Start is called before the first frame update
    void Start()
    {
        shop.SetActive(false);
        confirmMenu.SetActive(false);
        returnMenu.SetActive(false);
        advisoryText.SetActive(false);
        keyText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canEnterShop && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Keypad0))) ToggleAccessShop();
        if (shopIsOpen && Input.GetKeyDown(KeyCode.Escape)) ToggleAccessShop(); //Tambi�n se puede cerrar la tienda con ESC
    }

    public void ToggleAccessShop() //Funci�n que alterna la tienda: si el men� de la tienda est� cerrado lo abre y si est� abierto lo cierra
    {
        //Hay que parar el movimiento del jugador cuando se tenga ya su script
        shopIsOpen = !shopIsOpen;
        if (advisoryText.activeSelf) advisoryText.SetActive(false);
        shop.SetActive(!shop.activeSelf);
    }

    public void ToggleConfirmation() //Opci�n que habilita/deshabilita confirmaciones
    {
        confirmationEnabled = !confirmationEnabled;
        if (confirmationEnabled)
        {
            confirmationButton.GetComponentInChildren<TextMeshProUGUI>().text = "Desactivar confirmaciones";
        }
        else
        {
            confirmationButton.GetComponentInChildren<TextMeshProUGUI>().text = "Activar confirmaciones";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) canEnterShop = true;
        keyText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) canEnterShop = false;
        keyText.SetActive(false);
    }
}
