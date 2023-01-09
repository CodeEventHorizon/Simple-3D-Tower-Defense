using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moneyPrize = 20;
    public int moneyFine = 20;
    Money money;
    void Start()
    {
        money = FindObjectOfType<Money>();
    }
    public void GiveMoney()
    {
        if (money == null)
        {
            return;
        }
        money.AddMoney(moneyPrize);
    }
    public void TakeMoney()
    {
        if (money == null)
        {
            return;
        }
        money.SubtractMoney(moneyFine);
    }
}
