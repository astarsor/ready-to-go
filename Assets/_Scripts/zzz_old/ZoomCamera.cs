using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ZoomCamera : MonoBehaviour
{
    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;

    public void ZoomCam(InputAction.CallbackContext ctx)
    {
        float scrollVal = ctx.ReadValue<float>();

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit point;

        Physics.Raycast(ray, out point, 1000);
        Vector3 scrollDirection = ray.GetPoint(5);

        float step = zoomSpeed * Time.deltaTime;

        if (scrollVal > 0) //&& scrollDirection.y > minZoom)
        {
            print("zoom IN");
            transform.position = Vector3.MoveTowards(transform.position, scrollDirection, scrollVal * step);
        }
        else if (scrollVal < 0) //&& scrollDirection.y < maxZoom)
        {
            print("zoom OUT");
            transform.position = Vector3.MoveTowards(transform.position, scrollDirection, scrollVal * step);
        }
    }
}
