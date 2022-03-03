using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        UIManager.Instance.ChangeStateOfCanvas("Current");
    }

    public void Option()
    {
        UIManager.Instance.ChangeStateOfCanvas("Option");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
