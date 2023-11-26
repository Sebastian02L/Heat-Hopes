using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public int rutine;
    SpriteRenderer sprite;

    //Atributos para controlar el movimiento:
    public float speedWalk;
    public float speedRun;
    public bool isRight = true;
    public float leftXBound;
    public float rightXBound;

    //Atributos para perseguir al jugador;
    public GameObject target;
    public float visionRange=5f;
    public float attackRange=2f;

    //Atributos para atacar al jugador:
    public bool attacking;

    //Atributos para hacer sonidos
    public AudioSource playerDetected;

   private void Start() { 
        sprite=transform.GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Behaviours();
    }


    public void Behaviours()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > visionRange)
        { //Si no ve al jugador.

            //Si el audio se estaba reproduciendo
            if (playerDetected.isPlaying)
            {
                playerDetected.Stop();
            }

            //Movimiento del enemigo.
            if (isRight == true)
            {
                sprite.flipX = false;
                transform.position += Vector3.right * speedWalk * Time.fixedDeltaTime;
            }
            else
            {
                sprite.flipX=true;
                transform.position += Vector3.left * speedWalk * Time.fixedDeltaTime;
            }

            if (transform.position.x >= rightXBound)
            {
                isRight = false;
            }
            else if (transform.position.x <= leftXBound) 
            { 
                isRight = true;
            }
            
        }

        else if (Mathf.Abs(transform.position.y - target.transform.position.y) < visionRange)
        {
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > attackRange)
            { //Si ha visto al jugador pero no esta en rango de ataque entonces se debe acercar

                //Reproduce el audio si no está sonando
                if (!playerDetected.isPlaying)
                {
                    playerDetected.Play();
                }

                if (transform.position.x < target.transform.position.x)
                { //El jugador se encuentra a la derecha
                    sprite.flipX = false;
                    transform.Translate(Vector3.right * speedRun * Time.fixedDeltaTime);
                    
                }
                else
                {//El jugador se encuentra a la izquierda
                    sprite.flipX = true;
                    transform.Translate(Vector3.left * speedRun * Time.fixedDeltaTime);
                    
                }
            }

            else { //Si se encuentra dentro del rango de ataque
                
               GetComponent<EnemyAttack>();
            }

        }
    }
}
