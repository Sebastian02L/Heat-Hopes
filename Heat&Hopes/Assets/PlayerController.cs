using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float t; //Temporizador para aplicar el salto una sola vez
    private Rigidbody2D rb; //Referencia al componente Rigidbody
    public bool grounded; //parametro que dice si el perosanje esta en el suelo
    [Header("Atributos")]
    public float speed;
    public float jumpForce;
    public Vector3 groundedPoint; //La posición (respecto al centro del personaje) desde la que se comprueva si el personaje está en el suelo
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Consegimos la referencia
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (t < 0.1f) //Incremento de temporizador;
        {
            t += Time.deltaTime;
        }
        grounded = CheckGround();
        if (Input.anyKey)
        {
            MovementImput();
        }
        else
        {
            rb.velocity=new Vector2 (0,rb.velocity.y);
        }
    }

    private void MovementImput() //Esta funcion maneja el movimiento dependiendo de la tecla pulsada
    {
        //movimiento derecha
        if(Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y); //Se cambia la velocidad
        }
        //movimiento izquierda
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y); //Se cambia la velocidad
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        //salto
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))&&grounded&&t>=0.1f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Se aplica un impulso hacia arriba
            t = 0;
        }
    }

    private bool CheckGround()
    {
        return (Physics2D.Raycast(transform.position+groundedPoint, Vector2.down, 0.01f).collider != null);
    }
}
