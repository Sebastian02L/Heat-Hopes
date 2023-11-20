using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;
    public float cameraPosUp;
    public float cameraPosDown;
    public float speedTransition;
    private float cameraPosChange;
    

    void Start()
    {
        cameraPosChange = (cameraPosUp + cameraPosDown) / 2;  //Posición a partir de la cual la camara sube o baja
    }
    void FixedUpdate()
    {
        if (player.transform.position.y <= cameraPosChange) // Baja la camara
        {
            if (transform.position.y > cameraPosDown)
            {

                transform.position = new Vector3(player.transform.position.x, transform.position.y - Time.fixedDeltaTime * speedTransition, transform.position.z);
            }

            else 
            {
                transform.position = new Vector3(player.transform.position.x, cameraPosDown, transform.position.z);
            }

                

        }
        else //Sube la camara
        {
            if (transform.position.y < cameraPosUp)
            {
                transform.position = new Vector3(player.transform.position.x, transform.position.y + Time.fixedDeltaTime * speedTransition, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(player.transform.position.x, cameraPosUp, transform.position.z);
            }
        }

        
    }
}
