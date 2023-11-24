using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyActivable : MonoBehaviour
{
    public GameObject onRangeIndicator; //Indicador de que el jugador puede activarlo
    public GameObject notEnoughtMoneyIndicator; //Indicador de que el jugador no puede activarlo por falta de dinero
    public float notEnoughtMoneyShowTime; //Tiempo que se mostrará el indicador de falta de dinero
    public GameObject useConfirmation; //Si se necesita confirmación para usar se mostrará esto (si no requiere confirmación dejar vacío)
    protected PlayerInventoryManager moneyManager;
    public bool onRange;
    public bool confirming;
    public int price;
    public bool onlyOnce; //Por si solo se puede activar una vez
    public bool used;
    // Start is called before the first frame update
    protected void MoneyStart() //Este Start tiene que llamarlo el script hijo
    {
        moneyManager = GameObject.Find("Player").GetComponentInChildren<PlayerInventoryManager>(); //Referencia al dinero del jugador
        if (onRangeIndicator != null)
        {
            onRangeIndicator.SetActive(false);
        }
        if (notEnoughtMoneyIndicator != null)
        {
            notEnoughtMoneyIndicator.SetActive(false);
        }
        if (useConfirmation != null)
        {
            useConfirmation.SetActive(false);
        }
    }

    // Update is called once per frame
    protected void MoneyUpdate() //Este FixedUpdate tiene que llamarlo el script hijo
    {
        if (!onRange)
        {
            confirming = false;
        }
        onRangeIndicator.SetActive(onRange && !notEnoughtMoneyIndicator.activeSelf && !useConfirmation.activeSelf);
        useConfirmation.SetActive(confirming);
        if (onRange && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Keypad0)) && !used) 
        {
            if (moneyManager.money>=price)
            {

                if (useConfirmation == null) //Si no necesita confirmación se usa directamente
                {
                    Use();
                }
                else
                {
                    if (confirming)
                    {
                        Use();
                        confirming = false;
                    }
                    else
                    {
                        confirming=true;
                    }
                }
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
        moneyManager.AddMoney(-price);
        if (onlyOnce)
        {
            used = true;
        }
    }

    private void LowMoney() //Mostrar que el jugador no tiene suficiente dinero
    {
        notEnoughtMoneyIndicator.SetActive(true);
        if (notEnoughtMoneyIndicator.GetComponent<AudioSource>() != null)
        {
            notEnoughtMoneyIndicator.GetComponent<AudioSource>().Play();
        }
        Invoke("HideLowMoney",notEnoughtMoneyShowTime);
    }

    private void HideLowMoney()
    {
        notEnoughtMoneyIndicator.SetActive(false);
    }
}
