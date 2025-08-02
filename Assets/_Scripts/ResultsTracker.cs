using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(ResultsCanvasManager))]
public class ResultsTracker : MonoBehaviour
{
    public static Dictionary<EnumDescriptors, float> resultsTracker;

    void Awake()
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

    public static void AddToCount(int descriptorType, float val)
    {
        switch (descriptorType)
        {
            case 0: // HONEST
                resultsTracker[EnumDescriptors.honest] += val;
                break;
            case 1: // WISE
                resultsTracker[EnumDescriptors.wise] += val;
                break;
            case 2: // JOCK
                resultsTracker[EnumDescriptors.jock] += val;
                break;
            case 3: // ZEN
                resultsTracker[EnumDescriptors.zen] += val;
                break;
            case 4: // ROMANTIC
                resultsTracker[EnumDescriptors.romantic] += val;
                break;
            case 5: // PLAYFUL
                resultsTracker[EnumDescriptors.playful] += val;
                break;
            case 6: // COOL
                resultsTracker[EnumDescriptors.cool] += val;
                break;
        }
    }

    public Dictionary<EnumDescriptors, float> sortedTracker;

    public void SortResultsTracker()
    {
        var sorted = resultsTracker.OrderByDescending(key => key.Value);
        sortedTracker = sorted.ToDictionary(pair => pair.Key, pair => pair.Value);
    }
    public EnumDescriptors FirstResult()
    {
        return sortedTracker.ElementAt(0).Key;
    }
    public EnumDescriptors SecondResult()
    {
        return sortedTracker.ElementAt(1).Key;
    }
    public EnumDescriptors ThirdResult()
    {
        return sortedTracker.ElementAt(2).Key;
    }

}
