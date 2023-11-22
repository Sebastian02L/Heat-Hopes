using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb; //Referencia al componente Rigidbody
    public bool grounded; //Parametro que dice si el personaje esta en el suelo
    [Header("Atributos")]
    public float speed;
    public float jumpForce;
    private bool jump = false; //Bool que indica si el personaje salta o no
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Conseguimos la referencia
    }
    void FixedUpdate()
    {
        MovementInput();
    }

    private void Update()
    {
        JumpInput();
    }

    private void MovementInput() //Esta funcion maneja el movimiento dependiendo de la tecla pulsada
    {
        //movimiento derecha
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        //movimiento izquierda
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        //salto
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Se aplica un impulso hacia arriba
            jump = false;
        }
    }

    private void JumpInput() //El input del jump requiere un getKeyDown, por lo que debe de ser registrado en Update y no FixedUpdate
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && grounded)
        {
            jump = true;
        }
    }
}
