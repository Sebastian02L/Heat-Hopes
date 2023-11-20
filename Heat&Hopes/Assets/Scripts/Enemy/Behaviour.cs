using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public int rutine;

    //Atributos para controlar el movimiento:
    public float speed;
    public bool isRight;
    public float timerMovement;
    public float ChangeDirTime = 8f;

    //Atributos para perseguir y atacar al jugador:
    public GameObject target;
    public GameObject range;
    public GameObject hit;
    public bool attacking;
    public float visionRange;
    public float attackRange;
    

    void Start()
    {
        timerMovement = ChangeDirTime;
    }

    // Update is called once per frame
    void Update()
    {
        Behaviours();
    }

    public void Attack() {
        attacking = false;
        range.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void ColliderAttackTrue() { 
        hit.GetComponent<BoxCollider2D>().enabled = true;  
    }

    public void ColliderAttackFalse()
    {
        hit.GetComponent<BoxCollider2D>().enabled = false;
    }


    public void Behaviours()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > visionRange && !attacking)
        { //Si no ve al jugador ni se encuentra atacando.

            //Movimiento del enemigo.
            if (isRight == true)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            timerMovement -= Time.deltaTime;
            if (timerMovement <= 0)
            {
                timerMovement = ChangeDirTime;
                isRight = !isRight;
            }
        }

        else {
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > attackRange && !attacking)
            { //Si ha visto al jugador pero no esta en rango de ataque

                if (transform.position.x < target.transform.position.x)
                { //El jugador se encuentra a la derecha
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
                else
                {//El jugador se encuentra a la izquierda
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
            }

            else { //Si se encuentra dentro del rango de ataque
               
            }

        }
    }
}
