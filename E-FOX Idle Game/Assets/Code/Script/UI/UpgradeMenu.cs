using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    public int stateMultiplier = 1;

    public TMP_Text MultiplyText;

    public Button MulitplierButton;

    // Start is called before the first frame update
    void Start()
    {
        ChangeText(MultiplyText, stateMultiplier.ToString());
        MultiplyText.color = Color.white;
        MulitplierButton.image.color = Color.black;
    }

    private string ChangeMultiplier(int lastMultiplier)
    {
        switch(lastMultiplier)
        {
            case 1:
                stateMultiplier = 10;
                MulitplierButton.image.color = Color.green;
                MultiplyText.color = Color.black;
                break;
            case 10:
                stateMultiplier = 25;
                MulitplierButton.image.color = Color.yellow;
                break;
            case 25:
                stateMultiplier = 100;
                MulitplierButton.image.color = Color.red;
                MultiplyText.color = Color.white;
                break;
            case 100:
                stateMultiplier = 1;
                MulitplierButton.image.color = Color.black;
                MultiplyText.color = Color.white;
                break;
            default:
                stateMultiplier = 1;
                break;
        }

        return stateMultiplier.ToString();
    }

    private void ChangeText(TMP_Text TMProTxt, string textToChange)
    {
        TMProTxt.text = "x " + textToChange;
    }

    public void OnClickChangeMultiplier()
    {
        ChangeText(MultiplyText, ChangeMultiplier(stateMultiplier));
    }
}
