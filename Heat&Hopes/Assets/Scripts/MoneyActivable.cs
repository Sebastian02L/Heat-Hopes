using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyActivable : MonoBehaviour
{
    public GameObject onRangeIndicator; //Indicador de que el jugador puede activarlo
    protected PlayerInventoryManager moneyManager;
    public bool onRange;
    public int price;
    public bool onlyOnce; //Por si solo se puede activar una vez
    public bool used;
    // Start is called before the first frame update
    protected void MoneyStart() //Este Start tiene que llamarlo el script hijo
    {
        moneyManager = GameObject.Find("Player").GetComponentInChildren<PlayerInventoryManager>(); //Referencia al dinero del jugador
    }

    // Update is called once per frame
    protected void MoneyUpdate() //Este FixedUpdate tiene que llamarlo el script hijo
    {
        onRangeIndicator.SetActive(onRange);
        if (onRange && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Keypad0)) && !used) 
        {
            if (moneyManager.money>=price)
            {
                if (onlyOnce)
                {
                    used = true;
                }
                Use();
            }
            else
            {
                LowMoney();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //El gameObject necesita un Collider Trigger para funcionar
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //El gameObject necesita un Collider Trigger para funcionar
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onRange = false;
        }
    }

    protected virtual void Use() //Los scripts que hereden de este tendrán que implementar lo que harán al activarse
    {
        
    }

    private void LowMoney() //Mostrar que el jugador no tiene suficiente dinero (Interfaz?)
    {

    }
}
