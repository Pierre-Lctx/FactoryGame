using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    public GameObject GeneralUI;
    public GameObject TouchesUI;
    public GameObject GraphicsUI;
    public GameObject SonUI;
    public GameObject InGameUI;
    public GameObject CreditUI;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeneralMenu()
    {
        OpenUI("General");
    }

    public void TouchesMenu()
    {
        OpenUI("Touches");
    }

    public void GraphicsMenu()
    {
        OpenUI("Graphics");
    }

    public void SoundMenu()
    {
        OpenUI("Son");
    }

    public void InGameMenu()
    {
        OpenUI("InGame");
    }

    public void CreditMenu()
    {
        OpenUI("Credit");
    }

    public void BackButton()
    {
        UIManager.Instance.ChangeStateOfCanvas("Pause");
    }

    public void OpenUI(string UIName)
    {
        switch(UIName)
        {
            case "General":
                GeneralUI.SetActive(true);
                TouchesUI.SetActive(false);
                GraphicsUI.SetActive(false);
                SonUI.SetActive(false);
                InGameUI.SetActive(false);
                CreditUI.SetActive(false);
                break;
            case "Touches":
                GeneralUI.SetActive(false);
                TouchesUI.SetActive(true);
                GraphicsUI.SetActive(false);
                SonUI.SetActive(false);
                InGameUI.SetActive(false);
                CreditUI.SetActive(false);
                break;
            case "Graphics":
                GeneralUI.SetActive(false);
                TouchesUI.SetActive(false);
                GraphicsUI.SetActive(true);
                SonUI.SetActive(false);
                InGameUI.SetActive(false);
                CreditUI.SetActive(false);
                break;
            case "Son":
                GeneralUI.SetActive(false);
                TouchesUI.SetActive(false);
                GraphicsUI.SetActive(false);
                SonUI.SetActive(true);
                InGameUI.SetActive(false);
                CreditUI.SetActive(false);
                break;
            case "InGame":
                GeneralUI.SetActive(false);
                TouchesUI.SetActive(false);
                GraphicsUI.SetActive(false);
                SonUI.SetActive(false);
                InGameUI.SetActive(true);
                CreditUI.SetActive(false);
                break;
            case "Credit":
                GeneralUI.SetActive(false);
                TouchesUI.SetActive(false);
                GraphicsUI.SetActive(false);
                SonUI.SetActive(false);
                InGameUI.SetActive(false);
                CreditUI.SetActive(true);
                break;
            default:
                GeneralUI.SetActive(true);
                TouchesUI.SetActive(false);
                GraphicsUI.SetActive(false);
                SonUI.SetActive(false);
                InGameUI.SetActive(false);
                CreditUI.SetActive(false);
                break;
        }
    }
}
