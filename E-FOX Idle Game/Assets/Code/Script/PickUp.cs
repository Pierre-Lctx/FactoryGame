using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickUpRange = 10;
    private GameObject holdObject;

    public Transform holdParent;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (holdObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    if (!hit.transform.gameObject.name.Contains("Conveyor"))
                        PickUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }

            if (holdObject != null)
            {
                MoveObject();
            }
        }        
    }

    void MoveObject()
    {
        if (Vector3.Distance(holdObject.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - holdObject.transform.position);
            //holdObject.GetComponent<Rigidbody>().AddForce(moveDirection);
        }
    }

    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            holdObject = pickObj;
        }
    }

    void DropObject()
    {
        Rigidbody holdRig = holdObject.GetComponent<Rigidbody>();
        holdRig.GetComponent<Rigidbody>().useGravity = true;
        holdRig.drag = 1;

        holdObject.transform.parent = null;
        holdObject = null;
    }
}
