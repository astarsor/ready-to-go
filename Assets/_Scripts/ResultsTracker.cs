using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResultsTracker : MonoBehaviour
{
    public static ResultsTracker instance;
    public Dictionary<EnumDescriptors, float> resultsTracker;
    // public static UnityAction DoAddToCount;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        resultsTracker = new Dictionary<EnumDescriptors, float>()
        {
            {EnumDescriptors.honest, 0},
            {EnumDescriptors.wise, 0},
            {EnumDescriptors.jock, 0 },
            {EnumDescriptors.zen, 0},
            {EnumDescriptors.romantic, 0},
            {EnumDescriptors.playful, 0},
            {EnumDescriptors.cool, 0},
        };
    }

    public void AddToCount(int descriptorType, float val)
    {
        switch (descriptorType)
        {
            case 0:
                Debug.Log("adding a point for HONEST");
                break;
            case 1:
                Debug.Log("adding a point for WISE");
                break;
            case 2:
                Debug.Log("adding a point for JOCK");
                break;
            case 3:
                Debug.Log("adding a point for ZEN");
                break;
            case 4:
                Debug.Log("adding a point for ROMANTIC");
                break;
            case 5:
                Debug.Log("adding a point for PLAYFUL");
                break;
            case 6:
                Debug.Log("adding a point for COOL");
                break;
        }
        // big switch statement, 
        // (int)enumDescriptor as case numbers
        //      add DescriptorsHolder.value to... dictionary
    }


}
