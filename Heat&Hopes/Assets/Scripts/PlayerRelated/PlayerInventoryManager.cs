using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Newtonsoft.Json.Bson;

public class PlayerInventoryManager : MonoBehaviour
{
    //Dinero:
    public float money; //Dinero del jugador
    [SerializeField] private TextMeshProUGUI text; //Texto de la GUI que despliega el texto
    //�tems:                                               
    private PlayerController player;
    public Item[] items = new Item[5]; //Array de �tems del jugador
    private int indexItem = 0; //�ndice de �tem que est� activo
    private int numItems = 0; //N�mero de �tems que el jugador tiene actualmente
    private Item currentItem; //�tem seleccionado por el jugador
    //Energ�a:
    public float energy;
    public float maxEnergy = 2f;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        energy = 0;
        slider = GameObject.Find("EnergyBar").GetComponent<Slider>();
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
        //Con teclado:
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
        //Con rat�n:
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if (mouseWheel > 0) NextItem();
        else if (mouseWheel < 0) PreviousItem();
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
        items[numItems] = Instantiate(itemToAdd); 
        numItems++;
        //De momento no hay ning�n problema con que el inventario est� lleno al comprar un �tem, pues hay menos �tems que slots
    }

    public void RemoveItem(Item itemToRemove)
    {
        bool itemFound = false;
        for(int i = 0; i < items.Length && !itemFound; i++)
        {
            if (items[i].itemName == itemToRemove.itemName)
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
            indexItem = index;
            Debug.Log($"{currentItem.itemName} est� ahora activo");
        }
    }

    private void NextItem()
    {
        indexItem++;
        if (indexItem > numItems - 1) indexItem = 0;
        ChangeActiveItem(indexItem);
    }

    private void PreviousItem()
    {
        indexItem--;
        if (indexItem < 0 && numItems != 0) indexItem = numItems - 1;
        else if (numItems == 0) indexItem = 0;
        ChangeActiveItem(indexItem);
    }

    public void UpdateEnergy(float energyDif)
    {
        energy += energyDif;
        if (energy > maxEnergy) energy = maxEnergy;
        else if (energy < 0) energy = 0;
        slider.value = energy;
    }
}
