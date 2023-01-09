using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int towerCost = 50;
    public bool BuildTower(Tower tower, Vector3 position)
    {
        Money money = FindObjectOfType<Money>();
        if (money == null)
        {
            return false;
        }
        if (money.getMoney >= towerCost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            money.SubtractMoney(towerCost);
            return true;
        }
        return false;
    }
}
