using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionScript : MonoBehaviour
{
    private Image image;
    public bool blackTransition = false;
    public float speed;
    public float timer;
    public float startTimer;
    public float endTimer;

    // Update is called once per frame
    private void Start()
    {
        image = GetComponent<Image>();
        
    }
    void FixedUpdate()
    {
        if (startTimer <= 0)
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
                if (endTimer <= 0) 
                {
                    SceneManager.LoadScene(0);
                }
                endTimer -= Time.fixedDeltaTime;
            }
            timer -= Time.fixedDeltaTime * speed;
        }
        else
        {
            startTimer -= Time.fixedDeltaTime;
        }
    }
}
