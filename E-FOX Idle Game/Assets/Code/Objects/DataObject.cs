using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataObject : MonoBehaviour
{
    private ScriptableRessources _scriptableRessources;
    
    public void SetScriptableRessources(ScriptableRessources sr)
    {
        _scriptableRessources = sr;
    }

    public ScriptableRessources GetScriptableRessources()
    {
       return _scriptableRessources;
    }
}
