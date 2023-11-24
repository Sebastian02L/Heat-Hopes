using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestoyer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -50) 
        { 
            Destroy(gameObject);
        }
    }
}
