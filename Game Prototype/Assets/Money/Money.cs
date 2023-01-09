using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int startingMoney = 200;
    public int money;
    public Text moneyUI;
    void Awake()
    {
        money = startingMoney;
        reloadMoneyUI();
    }
    public void AddMoney(int moneyAmount)
    {
        money += Mathf.Abs(moneyAmount);
        reloadMoneyUI();
    }
    public void SubtractMoney(int moneyAmount)
    {
        money -= Mathf.Abs(moneyAmount);
        reloadMoneyUI();
        if(money < 0) {
            // Lose the game
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.buildIndex);
        }
    }
    public void reloadMoneyUI() {
        moneyUI.text = "Money: " + money;
    }
    public int getMoney
    {
        get
        {
            return money;
        }
    }
}
