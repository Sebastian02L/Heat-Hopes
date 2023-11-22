using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Sprite image; //Imagen que tiene en el men� de inventario y tienda
    public int cost; //Costo en la tienda del objeto
    public bool isActive; //Indica si el objeto est� seleccionado y puede ser usado
    public bool bought = false; //Indica si el �tem ha sido comprado o no
    public string itemName; //Nombre del �tem
    public string description; //Descripci�n del �tem
    public bool hasBeenUsed = false; //Indica si ha sido usado. En caso afirmativo no se podr� devolver en la tienda

    public void AddToInventory(string name) //A�ade el objeto al inventario del jugador (funcionalidad a a�adir)
    {
        Debug.Log($"{name} a�adido al inventario");
    }

    public void RemoveFromInventory(string name) //Elimina el objeto del inventario del jugador (funcionalidad a a�adir)
    {
        Debug.Log($"{name} eliminado del inventario");
    }

    //La funcionalidad de los objetos se implementa en el update de los mismos en un bucle if(isActive).
    //isActive se altera cuando el jugador selecciona desde el inventario qu� objeto quiere usar.
    //Una vez se entra dentro del if el booleano hasBeenUsed pasa a ser true y el objeto ya no se puede devolver.

    virtual protected void UseAbility() { }

    virtual public void ItemBought(bool state) { }
}