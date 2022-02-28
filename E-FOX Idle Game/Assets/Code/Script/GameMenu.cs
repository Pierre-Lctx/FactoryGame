using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public bool checkListArrows = false;
    public bool checkListConveyor = false;
    public bool checkListCartons = false;

    public bool displayArrows = false;
    public bool displayConveyors = false;
    public bool displayCarton = false;

    public bool clearCarton = false;
    
    public List<GameObject> DirectiveArrows;
    public List<GameObject> DirectiveConveyors;
    public List<GameObject> Cartons;
    private void Start()
    {
        CheckList(DirectiveArrows, "DirectiveArrow");
        CheckList(DirectiveConveyors, "Conveyor");
        CheckList(Cartons, "Carton Variant");
    }

    private void Update()
    {
        if(checkListArrows)
        {
            CheckList(DirectiveArrows, "DirectiveArrow");
            Debug.LogWarning("Liste des fleches des conveyors faites !");
        }

        if (checkListConveyor)
        {
            CheckList(DirectiveConveyors, "Conveyor");
            Debug.LogWarning("Liste des conveyors faites !");
        }

        if(checkListCartons)
        {
            CheckList(Cartons, "Carton Variant");
            Debug.LogWarning("Liste des cartons faites !");
        }

        if(displayArrows && DirectiveArrows != null)
        {
            DisplayObject(DirectiveArrows, true);
        }
        else
        {
            DisplayObject(DirectiveArrows, false);
        }

        if (displayConveyors && DirectiveConveyors != null)
        {
            DisplayObject(DirectiveConveyors, true);
        }
        else
        {
            DisplayObject(DirectiveConveyors, false);
        }

        if(displayCarton && Cartons != null)
        {
            DisplayObject(Cartons, true);
        }
        else
        {
            DisplayObject(Cartons, false);
        }

        if(clearCarton)
        {
            foreach(GameObject obj in Cartons)
            {
                Destroy(obj);
            }
            Cartons.Clear();
            clearCarton = false;
        }
    }

    private void CheckList(List<GameObject> list, string option)
    {
        GameObject[] gameObjects = FindObjectsOfType<GameObject>() as GameObject[];

        foreach (GameObject obj in gameObjects)
        {
            if (obj.name.Contains(option) && !list.Contains(obj))
            {
                list.Add(obj);
            }
        }
    }

    private void DisplayObject(List<GameObject> list, bool stateOfDisplaying)
    {
        foreach(GameObject obj in list)
        {
            obj.gameObject.SetActive(stateOfDisplaying);
        }
    }
}
