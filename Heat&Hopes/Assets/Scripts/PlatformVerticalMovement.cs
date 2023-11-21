using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVerticalMovement : MonoBehaviour
{
    public float speed = 1f;
    public float upLimit;
    public float downLimit;
    public bool goDown=true; //True para arriba y false para abajo
   
    void FixedUpdate() //De normal va hacia abajo, siempre que el bool goDown este puesto a true y la plataforma no se pase del limite inferior
    {
        if (goDown && transform.position.y >= downLimit) 
        { 
            transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) //Si el jugador la toca, esta pone a false goDown
    {
        if (other.collider.CompareTag("Player"))
        {
            goDown = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other) //Se mueve hacia arriba mientras el jugador esta encima
    {
        if (other.collider.CompareTag("Player")) 
        {
            if (transform.position.y <= upLimit)
                transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionExit2D(Collision2D other) //Si el jugador deja de tocarla, esta va a poner a true goDown
    {
        if (other.collider.CompareTag("Player"))
        {
            goDown = true;
        }
    }
}
