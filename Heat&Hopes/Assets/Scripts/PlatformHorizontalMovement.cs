using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontalMovement : MonoBehaviour
{
    private List<Transform> objectsTouching=new List<Transform>();
    public float speed = 1f;
    public float rightLimit;
    public float leftLimit;
    public bool direction=true; //True para derecha y false para izquierda
    void FixedUpdate()
    {


        if (direction)
        {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
            if (objectsTouching.Count > 0)
            {
                foreach (Transform t in objectsTouching)
                {
                    t.Translate(Vector3.right * speed * Time.fixedDeltaTime);
                }
            }
            if (transform.position.x >= rightLimit) 
            { 
                direction = false;
            }
        }
        else 
        {
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
            if (objectsTouching.Count > 0)
            {
                foreach (Transform t in objectsTouching)
                {
                    t.Translate(Vector3.left * speed * Time.fixedDeltaTime);
                }
            }
            if (transform.position.x <= leftLimit)
            {
                direction = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//Añadimos los objetos que tocan la plataforma a la lista para que se muevan ella
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>()!=null && collision.gameObject.GetComponent<Rigidbody2D>().bodyType==RigidbodyType2D.Dynamic && collision.gameObject.GetComponent<Rigidbody2D>().gravityScale!=0)
        {
            objectsTouching.Add(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)//Quitamos los objetos de la lista si dejan de tocar la plataforma
    {
        if (objectsTouching.Contains(collision.transform))
        {
            objectsTouching.Remove(collision.transform);
        }
    }
}
