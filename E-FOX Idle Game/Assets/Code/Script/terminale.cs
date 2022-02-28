using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terminale : MonoBehaviour
{
    MoneyGame moneyScript;
    // Start is called before the first frame update
    void Start()
    {
        moneyScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MoneyGame>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Carton Variant"))
        {
            //Changer les valeurs pour la sale
            moneyScript.Sale(1,1);
            Destroy(collision.gameObject);
        }
    }
}
