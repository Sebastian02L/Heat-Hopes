using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScript : MonoBehaviour
{
    private Image image;
    public bool blackTransition = false;
    public float speed;
    public float timer;

    // Update is called once per frame
    private void Start()
    {
        image = GetComponent<Image>();
        
    }
    void FixedUpdate()
    {
        if (blackTransition) 
        {
            image.color += new Color(0, 0, 0, speed * Time.fixedDeltaTime);
        }
        else
        {
            image.color -= new Color(0, 0, 0, speed * Time.fixedDeltaTime);
        }
        timer -= Time.fixedDeltaTime;
        if (timer <= 0) 
        {
            blackTransition = true;
        }
        timer -= Time.fixedDeltaTime* speed;
    }
}