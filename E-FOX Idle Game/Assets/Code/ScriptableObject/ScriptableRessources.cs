using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RessourcesManager", order = 1)]

public class ScriptableRessources : ScriptableObject
{
    public enum Type { Carton, Bois, Roche, Or, Diamand};

    public float Prix;
    public int xp;
    public GameObject gameObject;
    public Type type;
}
