using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkspoints : MonoBehaviour
{
    Vector2 checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        checkpoint= transform.position;
        Debug.Log(checkpoint);
    }

    // Update is called once per frame
    public void GoToCheckpoint() {
        transform.position = checkpoint;
    }

    public void UpdateCheckpoints()
    {
        checkpoint = transform.position;
    }
}
