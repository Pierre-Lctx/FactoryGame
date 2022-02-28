using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B : MonoBehaviour
{
    public A AFile;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AFile.coucou)
            Debug.Log("coucou From B");
    }
}
