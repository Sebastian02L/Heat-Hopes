using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyActivable : MonoBehaviour
{
    public GameObject onRangeIndicator; //Indicador de que el jugador puede activarlo
    private MoneyManager moneyManager;
    private float t;
    public bool onRange;
    public int price;
    public bool onlyOnce; //Por si solo se puede activar una vez
    public bool used;
    // Start is called before the first frame update
    protected void MoneyStart() //Este Start tiene que llamarlo el script hijo
    {
        moneyManager = GameObject.Find("Player").GetComponent<MoneyManager>(); //Referencia al dinero del jugador
    }

    // Update is called once per frame
    protected void MoneyFixedUpdate() //Este FixedUpdate tiene que llamarlo el script hijo
    {
        onRangeIndicator.SetActive(onRange);
        if (t > 0)
        {
            t -= Time.deltaTime;
        }
        if (onRange && (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.Keypad0)) && !used && t<=0) 
        {
            t = 0.5f;

            if (moneyManager.money>=price)
            {
                if (onlyOnce)
                {
                    used = true;
                }
                moneyManager.changeMoney(-price);
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
