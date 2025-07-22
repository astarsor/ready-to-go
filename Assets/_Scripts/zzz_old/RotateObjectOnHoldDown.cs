using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateObjectOnHoldDown : MonoBehaviour
{
    Vector3 prevPos = Vector3.zero;
    Vector3 posDelta = Vector3.zero;
    public bool holdingDown;
   

    void Start()
    {

    }

    void Update()
    {
        if (holdingDown)
        {
            posDelta = (Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue()) - prevPos) * 100;
            transform.Rotate(transform.up, Vector3.Dot(posDelta, -(Camera.main.transform.right)), Space.World);
            transform.Rotate(Camera.main.transform.right, Vector3.Dot(posDelta, Camera.main.transform.up), Space.World);
        }

        prevPos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
    }

    public void RotateOnHoldDown(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            // print("Mouse held down");
            holdingDown = true;
        }
        else if (ctx.canceled){
            // print("held up");
            holdingDown = false;
        }
    }

}
