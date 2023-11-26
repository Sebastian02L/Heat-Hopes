using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorController : MoneyActivable //Hereda de MoneyActivable
{
    private Animator animator; //Por si se usa una animaci�n;
    public float timeToDestroy; //Por si se quiere hacer una animaci�n de apertura de puerta
    public AudioSource openSound;
    [SerializeField] private TextMeshPro priceText;

    // Start is called before the first frame update
    void Start()
    {
        MoneyStart();
        animator = GetComponent<Animator>();
        priceText.text = $"{price}";
    }
    private void Update()
    {
        MoneyUpdate();
    }
    protected override void Use()
    {
        base.Use(); //Se tiene que utilizar la base de la funci�n
        openSound.Play();
        if (animator != null)
        {
            animator.SetTrigger("Open"); //Si hay una animaci�n de abrir, se tiene que iniciar con un trigger llamado Open
        }
        
        Destroy(gameObject,timeToDestroy);
        
    }
}
