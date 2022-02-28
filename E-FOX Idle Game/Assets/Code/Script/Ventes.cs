using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventes : MonoBehaviour
{
    public int numberOfSales;

    public GameObject Object;

    // Start is called before the first frame update
    void Start()
    {
        numberOfSales = 0;
        Object = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("box"))
        {
            Debug.Log("Collision");
            numberOfSales += 1;
        }
    }
}
