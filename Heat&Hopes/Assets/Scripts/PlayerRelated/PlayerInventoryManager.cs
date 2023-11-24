using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventoryManager : MonoBehaviour
{
    public float money; //Dinero del jugador
    [SerializeField] private TextMeshProUGUI text; //Texto de la GUI que despliega el texto
    private PlayerController player;
    public Item[] items = new Item[5]; //Array de �tems del jugador
    private int numItems = 0; //N�mero de �tems que el jugador tiene actualmente
    private Item currentItem; //�tem seleccionado por el jugador

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.canMove)
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeActiveItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeActiveItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeActiveItem(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeActiveItem(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeActiveItem(4);
        }
    }

    public void AddMoney(float moneyToAdd)
    {
        money += moneyToAdd;
        if (money < 0) money = 0;
        if (money > 1000) money = 1000;
        text.text = money.ToString();
    }

    public void AddItem(Item itemToAdd) //Se a�ade un clon del objeto de la tienda
    {
        Debug.Log($"{itemToAdd.itemName} a�adido al inventario");
        items[numItems] = itemToAdd; 
        numItems++;
        //De momento no hay ning�n problema con que el inventario est� lleno al comprar un �tem, pues hay menos �tems que slots
    }

    public void RemoveItem(Item itemToRemove)
    {
        bool itemFound = false;
        for(int i = 0; i < items.Length && !itemFound; i++)
        {
            if (items[i] == itemToRemove)
            {
                Debug.Log($"{itemToRemove.itemName} eliminado del inventario");
                itemFound = true;
                numItems--;
                for (int j = i; j < items.Length - 1; j++)
                {
                    items[j] = items[j + 1]; //Se elimina ese �tem sin dejar el hueco vac�o
                }
                items[items.Length - 2] = null; //El �ltimo elemento siempre va a estar vac�o si eliminas un objeto
            }
        }
    }

    private void ChangeActiveItem(int index)
    {
        if(currentItem != items[index] && items[index] != null) //Si el jugador no posee ning�n �tem en ese slot no se puede cambiar
        {
            if(currentItem != null) currentItem.isActive = false;
            if(currentItem != null) Debug.Log($"{currentItem.itemName} ha dejado de estar activo");
            currentItem = items[index];
            currentItem.isActive = true;
            Debug.Log($"{currentItem.itemName} est� ahora activo");
        }
    }
}
