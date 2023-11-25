using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb; //Referencia al componente Rigidbody
    public bool grounded; //Parametro que dice si el personaje esta en el suelo
    public bool canMove = true; //Booleano que indica si el jugador se puede mover o no
    [Header("Atributos")]
    public float speed;
    public float jumpForce;
    private bool jump = false; //Bool que indica si el personaje salta o no

    private Animator animator;

    private SpriteRenderer playerSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Conseguimos la referencia
        playerSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (canMove) MovementInput();
        else rb.velocity *= new Vector2(0, 1); //Se detiene su movimiento en seco en el eje x
    }

    private void Update()
    {
        if(canMove) JumpInput();

        if (grounded)
        {
            animator.SetBool("jumping", false);
        }
    }

    private void MovementInput() //Esta funcion maneja el movimiento dependiendo de la tecla pulsada
    {
        //movimiento derecha
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            playerSprite.flipX = true;

            if (grounded)
            {
                animator.SetBool("walking", true);
            }
        }
        //movimiento izquierda
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            playerSprite.flipX = false;

            if (grounded)
            {
                animator.SetBool("walking", true);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

            animator.SetBool("walking", false);
        }
        //salto
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Se aplica un impulso hacia arriba
            jump = false;

            animator.SetBool("jumping", true);
        }
    }

    private void JumpInput() //El input del jump requiere un getKeyDown, por lo que debe de ser registrado en Update y no FixedUpdate
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && grounded)
        {
            jump = true;
        }
    }

    public void ToggleMovement() //Altera el permiso de movimiento del jugador
    {
        canMove = !canMove;
    }
}
