using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_Text UsingText;

    public GameObject GameCanvas;
    public GameObject MenuAchat;
    public GameObject MenuPause;
    public GameObject OptionMenu;

    private bool isToggle;
    public bool result;
    public bool PauseIsActive;
    public bool UpgradeIsActive;

    public string UIToActive;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isToggle = false;
        result = true;

        PauseIsActive = false;
        UpgradeIsActive = false;

        MenuAchat.SetActive(true);
        MenuAchat.SetActive(false);
        GameCanvas.SetActive(false);
        OptionMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;

        ToggleUsingText(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !UpgradeIsActive)
        {
            UpgradeIsActive = true;
            PauseIsActive = false;

            ChangeStateOfCanvas("Upgrade");
            ChangeStateOfMouse();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !PauseIsActive)
        {
            UpgradeIsActive = false;
            PauseIsActive = true;

            ChangeStateOfCanvas("Pause");
        }
    }

    public void ChangeStateOfCanvas(string _UIToActive)
    {
        switch(_UIToActive)
        {
            case "Current":
                GameCanvas.SetActive(true);
                MenuAchat.SetActive(false);
                MenuPause.SetActive(false);
                OptionMenu.SetActive(false);
                ChangeStateOfMouse();
                Cursor.lockState =  CursorLockMode.Locked;
                break;
            case "Upgrade":
                GameCanvas.SetActive(false);
                MenuAchat.SetActive(true);
                MenuPause.SetActive(false);
                OptionMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Confined;
                break;
            case "Pause":
                GameCanvas.SetActive(false);
                MenuAchat.SetActive(false);
                MenuPause.SetActive(true);
                OptionMenu.SetActive(false);
                SetStateOfMouse(false);
                Cursor.lockState = CursorLockMode.Confined;
                break;
            case "Option":
                GameCanvas.SetActive(false);
                MenuAchat.SetActive(false);
                MenuPause.SetActive(false);
                OptionMenu.SetActive(true);
                SetStateOfMouse(false);
                Cursor.lockState = CursorLockMode.Confined;
                break;
            default:
                GameCanvas.SetActive(true);
                MenuAchat.SetActive(false);
                MenuPause.SetActive(false);
                OptionMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                break;
        }
    }

    public void ToggleUsingText(bool value)
    {
        UsingText.text = "Saisir (F)";

        UsingText.gameObject.SetActive(value);
    }

    public void ChangeStateOfMouse()
    {
        result = !result;
    }

    public void SetStateOfMouse(bool state)
    {
        result = state;
    }

    public bool GetStateOfMouse()
    {
        return result;
    }
}
