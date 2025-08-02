using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ItemTweens))]
[RequireComponent(typeof(DescriptorsHolder))]
public class ItemSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private DescriptorsHolder _myItemData;
    // private Descriptors[] _myDescriptors;
    // private EnumDescriptors _myEnumDescriptor;
    // private float _myDescriptorVal;


    private ItemTweens _itemTweens;
    private ItemHolderSpinner _itemSpinner;

    void Start()
    {
        _myItemData = GetComponent<DescriptorsHolder>();
        _itemTweens = GetComponent<ItemTweens>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _itemTweens.PauseBobberTween();
        if (transform.parent.TryGetComponent<ItemHolderSpinner>(out ItemHolderSpinner grabbedSpinner))
        {
            _itemSpinner = grabbedSpinner;
            _itemSpinner.PauseSpinnerTween();
        }

        // enable outline here
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _itemTweens.PlayBobberTween();
        _itemSpinner.PlaySpinnerTween();


        // remove outline here
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = 0; i < _myItemData.descriptors.Length; i++)
        {
            ResultsTracker.AddToCount((int)_myItemData.descriptors[i].enumDescriptors, _myItemData.descriptors[i].value);
        }

        _itemTweens.disposeSequence.Play();
        // GameManager.instance.NextRound();
    }
}
