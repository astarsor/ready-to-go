using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DecalPlacer : MonoBehaviour
{
    [SerializeField] private GameObject decalProjectorPrefab;
    [HideInInspector] public GameObject decalContainer;

    Ray currentRay;
    RaycastHit currentHit;

    public void PlaceDecal(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            
        }
    }
}
