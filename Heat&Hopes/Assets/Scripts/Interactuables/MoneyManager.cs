using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public PlayerController player;
    public int money;
    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<PlayerController>();
    }
    public void changeMoney(int quantity)
    {
        money += quantity;
        money=Mathf.Clamp(money, 0, int.MaxValue);
    }
}
