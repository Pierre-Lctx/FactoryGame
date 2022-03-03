using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControler : MonoBehaviour
{
    public GameObject buttonObject;

    public Material thisMaterial;

    public float speed = 1f;
    public float range = 5f;

    public bool isActivate = false;

    private void Start()
    {
        thisMaterial.color = Color.red;
    }

    // Update is called once per frame
    public void Use()
    {
        isActivate = !isActivate;

        if (isActivate)
        {
            thisMaterial.color = Color.green;
        }

        else
        {
            thisMaterial.color = Color.red;
        }
    }
}
