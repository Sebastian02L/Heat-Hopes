using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public int rutine;

    //Atributos para controlar el movimiento:
    public float speedWalk;
    public float speedRun;
    public bool isRight;
    public float timerMovement;
    public float ChangeDirTime = 8f;

    //Atributos para perseguir al jugador;
    public GameObject target;
    public float visionRange=5f;
    public float attackRange=2f;

    //Atributos para atacar al jugador:
    public bool attacking;
    

    void Start()
    {
        timerMovement = ChangeDirTime;
    }

    // Update is called once per frame
    void Update()
    {
        Behaviours();
    }


    public void Behaviours()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > visionRange)
        { //Si no ve al jugador.

            //Movimiento del enemigo.
            if (isRight == true)
            {
                transform.position += Vector3.right * speedWalk * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * speedWalk * Time.deltaTime;
            }

            timerMovement -= Time.deltaTime;
            if (timerMovement <= 0)
            {
                timerMovement = ChangeDirTime;
                isRight = !isRight;
            }
        }

        else {
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > attackRange)
            { //Si ha visto al jugador pero no esta en rango de ataque entonces se debe acercar

                if (transform.position.x < target.transform.position.x)
                { //El jugador se encuentra a la derecha
                    transform.Translate(Vector3.right * speedRun * Time.deltaTime);
                    
                }
                else
                {//El jugador se encuentra a la izquierda
                    transform.Translate(Vector3.left * speedRun * Time.deltaTime);
                    
                }
            }

            else { //Si se encuentra dentro del rango de ataque
                
               GetComponent<EnemyAttack>();
            }

        }
    }
}
