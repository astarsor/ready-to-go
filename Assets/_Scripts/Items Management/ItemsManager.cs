using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] private SO_EveryItemHolder _allItemsHolder;
    private List<GameObject> _itemPool;
    public GameObject[] itemParents = new GameObject[3];

    void Awake()
    {
        _itemPool = new List<GameObject>(_allItemsHolder.allItems);
    }

    // void Start()
    // {
    //     InstantiateSelections();        
    // }

    // RANDOMIZER
    [Space(5)]
    private int _randInt;
    private GameObject _selectedItem;

    public GameObject GetSelection()
    {
        // get a selection ready
        _randInt = RandomFromPool();
        _selectedItem = _itemPool[_randInt];
        return _selectedItem;
    }
    public int RandomFromPool()
    {
        int _randomFromPool = Random.Range(0, _itemPool.Count);
        return _randomFromPool;
    }
    public void RemoveSelectionFromPool(GameObject choice)   // call after sending selection to itemParentn
    {
        // remove current selection from pool to get ready for next selection
        _itemPool.Remove(choice);
    }


    // INSTANTIATE TO PREPARE FOR SHOWING
    public void InstantiateSelections()
    {
        // attempt to make newChoice a child of itemParents[0], if not move to next itemParent
        for (int i = 0; i < itemParents.Length; i++)
        {
            GameObject newChoice = GetSelection();

            if (itemParents[i].transform.childCount == 0)
            {
                Debug.Log("instantiating at: " + itemParents[i].name);

                GameObject itemObj = Instantiate(newChoice);
                itemObj.transform.parent = itemParents[i].transform;
                itemObj.transform.localPosition = newChoice.transform.position;

                RemoveSelectionFromPool(newChoice);
            }
            else
            {
                Debug.Log("no room at " + itemParents[i].name + "!");

                // Sequence instantiateSequence = DOTween.Sequence();
                // instantiateSequence
                //     .PrependCallback
                //     (
                //         () => itemParents[i].transform.GetChild(0).gameObject.GetComponent<ItemBobber>().disposeSequence.Play()
                //     );
            }
        }
    }
    public void MakeRoomForNextRound()
    {
        for (int i = 0; i < itemParents.Length; i++)
        {
            Debug.Log("making room at " + itemParents[i].name + "...");
            Destroy(itemParents[i].transform.GetChild(0).gameObject);
        }
    }
}
