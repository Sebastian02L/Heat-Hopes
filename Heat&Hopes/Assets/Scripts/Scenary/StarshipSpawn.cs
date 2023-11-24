using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class StarshipSpawn : MonoBehaviour
{
    public GameObject player;
    public float t;
    public float offsetX;
    public GameObject[] starships;

    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (t <= 0) 
        {
            Instantiate(starships[Random.Range(0, 4)],new Vector3(player.transform.position.x + offsetX, player.transform.position.y + Random.Range(0,5), -8f),Quaternion.Euler(new Vector3(0f,0f,90f)));
            t = Random.Range(5, 20);
        }
        t -= Time.deltaTime;
    }
}
