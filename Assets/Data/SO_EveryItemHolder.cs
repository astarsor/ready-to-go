using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "All Items Ever", menuName = "Persistent Data/All Items Holder")]
public class SO_EveryItemHolder : ScriptableObject
{
    public GameObject[] allItems;
}
