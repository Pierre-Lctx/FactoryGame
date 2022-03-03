using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    Rigidbody rBody;

    public ScriptableConveyor scriptableConveyor;

    public GameObject DirectiveArrowForward;
    public GameObject DirectiveArrowLeft;
    public GameObject DirectiveArrowRight;
    public GameObject DirectiveArrowBack;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    public Vector3 SelectDirection(ScriptableConveyor.Direction direction)
    {
        switch(direction)
        {
            case ScriptableConveyor.Direction.Forward:
                return Vector3.forward;
            case ScriptableConveyor.Direction.Left:
                return Vector3.left;
            case ScriptableConveyor.Direction.Right:
                return Vector3.right;
            case ScriptableConveyor.Direction.Back:
                return Vector3.back;
            default:
                return Vector3.forward;
        }
    }

    public void ShowArrow(ScriptableConveyor.Direction direction)
    {
        switch (direction)
        {
            case ScriptableConveyor.Direction.Forward:
                DirectiveArrowForward.SetActive(true);
                DirectiveArrowLeft.SetActive(false);
                DirectiveArrowRight.SetActive(false);
                DirectiveArrowBack.SetActive(false);
                break;

            case ScriptableConveyor.Direction.Left:
                DirectiveArrowForward.SetActive(false);
                DirectiveArrowLeft.SetActive(true);
                DirectiveArrowRight.SetActive(false);
                DirectiveArrowBack.SetActive(false);
                break;

            case ScriptableConveyor.Direction.Right:
                DirectiveArrowForward.SetActive(false);
                DirectiveArrowLeft.SetActive(false);
                DirectiveArrowRight.SetActive(true);
                DirectiveArrowBack.SetActive(false);
                break;

            case ScriptableConveyor.Direction.Back:
                DirectiveArrowForward.SetActive(false);
                DirectiveArrowLeft.SetActive(false);
                DirectiveArrowRight.SetActive(false);
                DirectiveArrowBack.SetActive(true);
                break;

            default:
                DirectiveArrowForward.SetActive(false);
                DirectiveArrowLeft.SetActive(false);
                DirectiveArrowRight.SetActive(false);
                DirectiveArrowBack.SetActive(false);
                break;
        }
    }

    private void FixedUpdate()
    {
        Vector3 pos = rBody.position;
        rBody.position += SelectDirection(scriptableConveyor.direction) * scriptableConveyor.speed * Time.deltaTime;
        rBody.MovePosition(pos);
        ShowArrow(scriptableConveyor.direction);
    }
}
