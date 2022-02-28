using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyGame : MonoBehaviour
{
    public float money;

    public int level;
    public int xp;
    public int maxXp;

    public int countMoneyGameSale;

    public Image mask;

    public bool isSale = false;

    public Text MoneyText;
    public Text levelText;
    public Text xpText;

    public int numberOfSale;

    // Start is called before the first frame update
    void Start()
    {
        money = 0f;

        numberOfSale = 0;

        level = 0;
        xp = 0;
        maxXp = 2;

        countMoneyGameSale = 0;
        ChangeText();
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)xp / (float)maxXp;
        Vector3 size = new Vector3 (fillAmount, 1, 0);
        mask.rectTransform.localScale = size;
    }

    public void ChangeLevel()
    {
        level += 1;

        maxXp = maxXp * 2;

        xp = 0;
    }

    public void ChangeText()
    {
        MoneyText.text = money.ToString() + " $";
        levelText.text = ("Level " + level).ToString();
        xpText.text = (xp + "/" + maxXp).ToString();
    }

    public void Sale(float salePrice, int xpLocal)
    {
        money += salePrice;
        xp += xpLocal;
        Debug.Log("Vendu, +1xp");

        MoneyText.text = money.ToString() + " $";

        ChangeText();

        if (xp >= maxXp)
        {
            ChangeLevel();
            Debug.Log("ChangeLevel");
            Debug.Log(("money = " + money).ToString());
        }

        ChangeText();
    }
}
