using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Sprite image; //Imagen que tiene en el menú de inventario y tienda
    public int cost; //Costo en la tienda del objeto
    public bool isActive = false; //Indica si el objeto está seleccionado y puede ser usado
    public bool bought = false; //Indica si el ítem ha sido comprado o no
    public string itemName; //Nombre del ítem
    public string description; //Descripción del ítem
    public bool hasBeenUsed = false; //Indica si ha sido usado. En caso afirmativo no se podrá devolver en la tienda
    //Para los ajustes de idioma:
    protected string language;
    protected string spanishName;
    protected string spanishDescription;
    protected string englishName;
    protected string englishDescription;
    //La funcionalidad de los objetos se implementa en el update de los mismos en un bucle if(isActive).
    //isActive se altera cuando el jugador selecciona desde el inventario qué objeto quiere usar.
    //Una vez se entra dentro del if el booleano hasBeenUsed pasa a ser true y el objeto ya no se puede devolver.

    virtual protected void UseAbility() { }

    virtual public void ItemBought(bool state) { }

    virtual public void ChangeItemStatus() {}

    protected void CheckLanguage()
    {
        language = LocalizationSettings.SelectedLocale.LocaleName;
        if (language == "Spanish (es)")
        {
            itemName = spanishName;
            description = spanishDescription;
        }
        else
        {
            itemName = englishName;
            description = englishDescription;
        }
    }
}
