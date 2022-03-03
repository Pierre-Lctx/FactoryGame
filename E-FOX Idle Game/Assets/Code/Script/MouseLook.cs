using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public bool isManette = false;

    //Utilisation des boutons dans le jeu
    //[SerializeField]
    //private Text UseText;
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private float MaxUseDistance = 5f;
    [SerializeField]
    private LayerMask UseLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }*/

        /*if (isManette)
        {
            float manetteX = Input.GetAxis("HManette");
            float manetteY = Input.GetAxis("VManette");

            xRotation -= manetteY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * manetteX);
        }*/
        if (UIManager.Instance.GetStateOfMouse())
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        
        
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers) 
            && hit.collider.TryGetComponent<ButtonControler>(out ButtonControler buttonControler))
        {
            if (hit.collider.gameObject.CompareTag("Ressource"))
            {
                UIManager.Instance.ToggleUsingText(true);
                Debug.DrawRay(transform.position, hit.point, Color.red);
            }
            else
            {
                UIManager.Instance.ToggleUsingText(false);
            }
            /*
            if (buttonControler.isActivate)
            {
                UseText.text = "Press \"E\" to switch ON !";
            }
            else
            {
                UseText.text = "Press \"E\" to switch OFF !";
            }
            UseText.gameObject.SetActive(true);
            UseText.transform.position = hit.point - (hit.point - Camera.position).normalized * 0.01f;
            UseText.transform.rotation = Quaternion.LookRotation((hit.point - Camera.position).normalized);*/
        }
    }

    /*void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        GameIsPaused = true;
    }*/


    //Utilisation d'un bouton
    

    public void OnUse()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers))
        {
            if (hit.collider.TryGetComponent<ButtonControler>(out ButtonControler buttonControler))
            {
                if (buttonControler.isActivate)
                {
                    buttonControler.Use();
                }
            }
        }
    }

    public void LockCameraMovement()
    {
        mouseSensitivity = 0f;
    }

    public void UnlockCameraMovement()
    {
        mouseSensitivity = 100f;
    }
}
