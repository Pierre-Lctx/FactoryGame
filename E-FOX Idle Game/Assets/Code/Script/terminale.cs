using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terminale : MonoBehaviour
{
    public ScriptableRessources ressources;
    MoneyGame moneyScript;
    // Start is called before the first frame update
    void Start()
    {
        moneyScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MoneyGame>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(CheckItemExist(collision))
        {
            //Changer les valeurs pour la sale
            moneyScript.Sale(collision.gameObject.GetComponent<DataObject>().GetScriptableRessources().Prix, collision.gameObject.GetComponent<DataObject>().GetScriptableRessources().xp);
            Destroy(collision.gameObject);
        }
    }

    private bool CheckItemExist(Collision collision)
    {
        if (collision.gameObject.name.Contains("Carton"))
            return true;
        else if (collision.gameObject.name.Contains("Bois"))
            return true;
        else if (collision.gameObject.name.Contains("Or"))
            return true;
        else if (collision.gameObject.name.Contains("Diamand"))
            return true;
        else if (collision.gameObject.name.Contains("Roche"))
            return true;
        else if (collision.gameObject.name.Contains("Stone"))
            return true;
        else
            return false;
    }
}
