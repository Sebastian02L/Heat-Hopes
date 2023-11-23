using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Shop shop; //Tienda a la que pertenece
    [SerializeField] private Image itemImage; //Imagen del ítem 
    [SerializeField] private TextMeshProUGUI nameText; //Texto para el nombre del ítem
    [SerializeField] private TextMeshProUGUI descriptionText; //Texto para la descripción del ítem
    [SerializeField] private Button button; //Botón de compra
    [SerializeField] private GameObject confirmMenu; //Menú de confirmación de compra
    [SerializeField] private GameObject shopMenu; //Menú de la tienda
    [SerializeField] private GameObject returnMenu; //Menú de devolución de objeto
    [SerializeField] private TextMeshProUGUI advisoryText; //Texto de advertencia tras comprar / vender
    private Item item; //Item que se está vendiendo 
    private GameObject player; //Hay que acceder al dinero del jugador
    private PlayerInventoryManager playerInventory; //Dinero del jugador (almacenado de momento en un string)
    private string costInfo; //Cadena que se muestra la información de compra del objeto
    private TextMeshProUGUI buttonString; //Texto del botón
    private bool canBeBought = true; //Indica si un ítem se puede comprar o no
    
    private static Item itemToBuy; //Guarda el ítem que se ha seleccionado en la tienda para el botón de confirmación
    


    // Start is called before the first frame update
    void Awake()
    {
        //Se configura la vista del objeto en pantalla:
        item = GetComponent<Item>();
        itemImage.GetComponent<Image>().sprite = item.image;
        nameText.text = item.itemName;
        descriptionText.text = item.description;
        costInfo = $"{item.cost}";
        buttonString = button.GetComponentInChildren<TextMeshProUGUI>();
        buttonString.text = costInfo;
        //Variables del jugador:
        player = GameObject.FindWithTag("Player");
        playerInventory = player.GetComponentInChildren<PlayerInventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (item.bought && !item.hasBeenUsed) //El jugador posee el ítem y lo puede vender
        {
            button.image.color = new Color(1.0f, 1.0f, 0.64f, 1.0f);
            buttonString.text = $"Vender - {item.cost}";
            canBeBought = false;
        }
        else if(item.bought && item.hasBeenUsed) //El jugador posee el ítem y no lo puede vender
        {
            button.image.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
            buttonString.text = "Obtenido";
            canBeBought = false;
        }
        else if (playerInventory.money < item.cost) //El jugador no posee el ítem y no lo puede comprar
        {
            button.image.color = new Color(1.0f, 0.32f, 0.32f, 1.0f);
            buttonString.text = costInfo;
            canBeBought = false;
        }
        else //El jugador no posee el ítem y lo puede comprar
        {
            button.image.color = new Color(0.63f, 1.0f, 0.63f, 1.0f);
            buttonString.text = costInfo;
            canBeBought = true;
        }
    }

    public void BuyItem() //Función llamada cuando se pulsa un objeto de la tienda
    {
        itemToBuy = item; //Guarda el ítem seleccionado. Será necesario en caso de que las confirmaciones estén activadas
        bool confirmation = shop.confirmationEnabled; //Este booleano debería estar en otro sitio, no en la tienda.
                                                      //De momento, al no tener el resto programado, se implementa así
        if (canBeBought) //Si no lo tienes comprado te permite comprarlo
        {
            if (confirmation) //Si las confirmaciones están activadas se pregunta al jugador si realmente lo quiere comprar
            {
                shop.ToggleEnableAccess(); //Mientras esté desplegado el menú de confirmación la tienda no se puede abrir la tienda de nuevo para evitar bugs
                confirmMenu.GetComponentInChildren<TextMeshProUGUI>().text = $"¿Seguro que desea comprar '{itemToBuy.itemName}'? Podrá devolverlo si no lo usa.";
                shopMenu.SetActive(false);
                confirmMenu.SetActive(true);
            }
            else //Si no se realiza la compra directamente
            {
                ConfirmPurchase();
            }
        }
        else if (item.bought && !item.hasBeenUsed) //Si lo tienes comprado y no lo ha usado te permite devolverlo
        {
            if (confirmation) //Si las confirmaciones están activadas se pregunta al jugador si realmente lo quiere devolver
            {
                shop.ToggleEnableAccess();
                returnMenu.GetComponentInChildren<TextMeshProUGUI>().text = $"¿Seguro que desea devolver '{itemToBuy.itemName}'?";
                shopMenu.SetActive(false);
                returnMenu.SetActive(true);
            }
            else //Si no se realiza la devolución directamente
            {
                ReturnObject();
            }
        } 
        else if(!item.bought && playerInventory.money < item.cost) //Si no se puede comprar a falta de dinero se muestra que el jugador es pobre
        {
            advisoryText.text = "¡Dinero insuficiente!";
            StartCoroutine(ShowAdvisoryText());
        }
    }

    public void ConfirmPurchase() //Realiza la compra
    {
        itemToBuy.ItemBought(true);
        itemToBuy.AddToInventory(itemToBuy.itemName);
        playerInventory.AddMoney(-itemToBuy.cost);
        advisoryText.text = $"{itemToBuy.itemName} añadido al inventario con éxito.";
        StartCoroutine(ShowAdvisoryText());
    }

    public void ReturnObject() //Realiza la devolución
    {
        itemToBuy.ItemBought(false);
        itemToBuy.RemoveFromInventory(itemToBuy.itemName);
        playerInventory.AddMoney(itemToBuy.cost);
        advisoryText.text = $"{itemToBuy.itemName} devuelto con éxito.";
        StartCoroutine(ShowAdvisoryText());
    }

    IEnumerator ShowAdvisoryText()
    {
        string originalString = advisoryText.text;
        advisoryText.transform.parent.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        string finalString = advisoryText.text;
        if(originalString == finalString) advisoryText.transform.parent.gameObject.SetActive(false); //Si el contenido ha cambiado el cuadro no desaparece
                                                                                                     //Significa que el jugador ha tocado algo que ha hecho surgir otro texto
                                                                                                     //emergente, por lo que los 3 segundos se resetean
    }
}
