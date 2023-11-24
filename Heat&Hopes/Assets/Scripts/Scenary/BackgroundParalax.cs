using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParalax : MonoBehaviour
{
    public GameObject cam;
    public float last;
    public float current;
    public float speed;
    public float distance;
    private float t;

    private void Start()
    {
        current = cam.transform.position.x;
    }
    void FixedUpdate()
    {

        last = cam.transform.position.x;
        if (Mathf.Abs(last - current) >= distance) 
        { 
        if (last < current)
            {
                transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
            }
            else if (last > current)
            {
                transform.position -= new Vector3(speed * Time.fixedDeltaTime, 0, 0);
            }
        }
        current = last;
    }
}
