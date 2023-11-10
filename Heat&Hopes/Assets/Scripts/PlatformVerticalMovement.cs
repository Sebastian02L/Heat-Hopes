using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVerticalMovement : MonoBehaviour
{
    public float speed = 1f;
    public float upLimit;
    public float downLimit;
    public bool direction=true; //True para arriba y false para abajo
    void FixedUpdate()
    {


        if (direction)
        {
            transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
            Debug.Log("Para arriba =>"+upLimit+" vs "+transform.position.y);
            if (transform.position.y > upLimit) 
            { 
                direction = false;
            }
        }
        else 
        {
            transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);
            Debug.Log("Para abajo =>" + downLimit + " vs " + transform.position.y);
            if (transform.position.y < downLimit)
            {
                direction = true;
            }
        }
    }
}
