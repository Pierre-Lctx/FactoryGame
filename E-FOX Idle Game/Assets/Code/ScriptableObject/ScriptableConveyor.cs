using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]

public class ScriptableConveyor : ScriptableObject
{
    public enum Direction {Forward, Left, Right, Back};

    public float speed;
    public Direction direction;
}
