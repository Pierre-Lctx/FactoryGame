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

    private bool isToggle;
    public bool result;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isToggle = false;
        result = true;

        MenuAchat.SetActive(isToggle);
        GameCanvas.SetActive(!isToggle);

        Cursor.lockState = CursorLockMode.Locked;

        ToggleUsingText(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeStateOfCanvas();
            ChangeStateOfMouse();
        }
    }

    private void ChangeStateOfCanvas()
    {
        isToggle = !isToggle;

        MenuAchat.SetActive(isToggle);
        GameCanvas.SetActive(!isToggle);

        Cursor.lockState = isToggle ? CursorLockMode.Confined : CursorLockMode.Locked;
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

    public bool GetStateOfMouse()
    {
        return result;
    }
}
