using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class GetSelectionRaycast : MonoBehaviour
{
    private Camera cam;
    
    public LayerMask selectableLayer;
    private Transform _selection;
    private Transform _highlight;
    private RaycastHit _raycastHit;

    private RotateObjectOnHoldDown _objRotater;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (_highlight != null)
        {
            // _highlight.gameObject.GetComponent<SheepOutline>().enabled = false;
            _highlight = null;
        }

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue()); //Input.mouseposition

        if (Physics.Raycast(ray, out _raycastHit, 500, selectableLayer.value))
        {
            _highlight = _raycastHit.transform;

            if (_highlight != _selection && _highlight.gameObject.GetComponent<RotateObjectOnHoldDown>() != null)
            {
                // print("hovering on selectable object");


                // if (_highlight.gameObject.GetComponent<RotateObjectOnHoldDown>() != null)
                //     print("hovering on selectable object");
                // else
                //     print("no script attached");

                // outline stuff goes here
            }
            else
            {
                _highlight = null;
                // print("looking...");
            }
        }
    }

    public void GetSelection(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _selection = _raycastHit.transform;

            if (_highlight)
            {
                // outline stuff goes here

            // SELECT
                print("SELECTION: " + _selection);
                _objRotater = _selection.gameObject.GetComponent<RotateObjectOnHoldDown>();
                _highlight = null;
            }
            else
            {
            // UNSELECT
                if (_selection) // if player selects on selected obj again
                {
                    // ...

                    _selection = null;
                }
            }
        }
    }

    public void RotateSelectedObject(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _objRotater.holdingDown = true;
        }
        else if (ctx.canceled)
        {
            _objRotater.holdingDown = false;
        }
    }
}
