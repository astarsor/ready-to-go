using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ItemBobber))]
[RequireComponent(typeof(DescriptorsHolder))]
public class ItemSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private ItemHolderSpinner _itemSpinner;
    private ItemBobber _itemBobber;
    void Start()
    {
        _itemBobber = GetComponent<ItemBobber>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("hovering on selectable object");
        _itemBobber.PauseTween();
        if (transform.parent.TryGetComponent<ItemHolderSpinner>(out ItemHolderSpinner grabbedSpinner))
        {
            _itemSpinner = grabbedSpinner;
            _itemSpinner.PauseTween();
        }

        // enable outline here
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exited");
        _itemBobber.PlayTween();
        _itemSpinner.PlayTween();


        // remove outline here
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("selected");
        //_player.itemSelection = gameObject;     // do i even need to send any info elsewhere besides the results tracker
    }
}
