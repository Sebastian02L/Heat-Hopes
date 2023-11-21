using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilityManager : MonoBehaviour
{
    public PlayerController player;
    public int energy;
    // Start is called before the first frame update
    void Awake()
    {
        player=GetComponent<PlayerController>();
    }

    public void changeEnergy(int quantity)
    {
        energy += quantity;
        energy = Mathf.Clamp(energy, 0, int.MaxValue);

    }
}
