using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontalMovement : MonoBehaviour
{
    public float speed = 1f;
    public float rightLimit;
    public float leftLimit;
    public bool direction=true; //True para derecha y false para izquierda
    void FixedUpdate()
    {


        if (direction)
        {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
            if (transform.position.x >= rightLimit) 
            { 
                direction = false;
            }
        }
        else 
        {
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
            if (transform.position.x <= leftLimit)
            {
                direction = true;
            }
        }
    }
}
