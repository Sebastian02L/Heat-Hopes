using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorController : MoneyActivable //Hereda de MoneyActivable
{
    private Animator animator; //Por si se usa una animación;
    public float timeToDestroy; //Por si se quiere hacer una animación de apertura de puerta
    [SerializeField] private TextMeshPro priceText;
    // Start is called before the first frame update
    void Start()
    {
        MoneyStart();
        animator = GetComponent<Animator>();
        priceText.text = $"{price} HV";
    }
    private void Update()
    {
        MoneyUpdate();
    }
    protected override void Use()
    {
        if (animator != null)
        {
            animator.SetTrigger("Open"); //Si hay una animación de abrir, se tiene que iniciar con un trigger llamado Open
        }
        moneyManager.AddMoney(-price);
        Destroy(gameObject,timeToDestroy);
    }
}
