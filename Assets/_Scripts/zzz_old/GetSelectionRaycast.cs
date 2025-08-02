using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class GetSelectionRaycast : MonoBehaviour
{
    private Camera cam;
    
    public LayerMask selectableLayer;
    private Transform _selection;
    private Transform _highlight;
    private RaycastHit _raycastHit;
    
    void Start()
    {
        cam = Camera.main;
    }

    private ItemTweens _itemBobber;
    private ItemHolderSpinner _itemSpinner;
    void Update()
    {
        if (_highlight != null)
        {
            // _highlight.gameObject.GetComponent<SheepOutline>().enabled = false;
            _highlight = null;
        }

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out _raycastHit, 500, selectableLayer.value))
        {
            _highlight = _raycastHit.transform;

            // if (_highlight.gameObject.TryGetComponent<ItemBobber>(out ItemBobber grabbedBobber))
            // {
            //     _itemBobber = grabbedBobber;
            // }


            if (_highlight != _selection && _highlight.gameObject.CompareTag("Selectable"))
            {
                Debug.Log("hovering on selectable");
                if (_highlight.parent.TryGetComponent<ItemHolderSpinner>(out ItemHolderSpinner grabbedSpinner))
                {
                    _itemSpinner = grabbedSpinner;
                    _itemSpinner.PauseSpinnerTween();
                }

                // outline stuff goes here
            }
            // else if (_itemSpinner != null)
            // {
            //     _itemSpinner.spinnerSequence.Play();
            // }
            else
            {
                _itemSpinner.PlaySpinnerTween();
                _highlight = null;
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
                            // _objRotater = _selection.gameObject.GetComponent<RotateObjectOnHoldDown>();
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

    // public void RotateSelectedObject(InputAction.CallbackContext ctx)
    // {
    //     if (ctx.performed)
    //     {
    //         _objRotater.holdingDown = true;
    //     }
    //     else if (ctx.canceled)
    //     {
    //         _objRotater.holdingDown = false;
    //     }
    // }
}
