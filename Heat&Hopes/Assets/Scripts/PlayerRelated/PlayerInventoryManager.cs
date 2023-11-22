using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventoryManager : MonoBehaviour
{
    public float money;
    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(float moneyToAdd)
    {
        money += moneyToAdd;
        if (money < 0) money = 0;
        if (money > 1000) money = 1000;
        text.text = money.ToString();
    }
}
