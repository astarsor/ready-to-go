using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ResultsTracker))]
public class ResultsCanvasManager : MonoBehaviour
{
    private ResultsTracker _resultsTracker;
    public TextMeshProUGUI mainHeadingText,
        descriptor1, descriptor2, descriptor3,
        luckyNumberText,
        fortuneText,
        hobby1Text, hobby2Text,
        weakPointText;
    public List<string> mainHeadingsList;
    public List<string> luckyNumbersList;
    public List<string> fortunesList;
    public List<string> hobbysList;
    public List<string> weakPointsList;

    void Awake()
    {
        _resultsTracker = GetComponent<ResultsTracker>();
        GameManager.OnShowResults += PrepareResults;
    }
    void OnDisable()
    {
        GameManager.OnShowResults -= PrepareResults;
    }

    public void PrepareResults()
    {
        // read from tracker
        _resultsTracker.SortResultsTracker();
        // print($"1. {descriptor_first}");
        // print($"2. {descriptor_second}");
        // print($"3. {descriptor_third}");

        EnumDescriptors descriptor_first = _resultsTracker.FirstResult();
        EnumDescriptors descriptor_second = _resultsTracker.SecondResult();
        EnumDescriptors descriptor_third = _resultsTracker.ThirdResult();

        SetTopThreeDescriptors(descriptor_first, descriptor_second, descriptor_third);
        SetMainHeadingText((int)descriptor_first);

        SetHobbyTexts();
        SetFortuneText((int)descriptor_first);
        SetLuckyNumberText((int)descriptor_first);
        SetWeakPointText((int)descriptor_first);
    }


    private void SetMainHeadingText(int mainDescriptor)
    {
        mainHeadingText.text = mainHeadingsList[mainDescriptor];
    }

    private void SetTopThreeDescriptors(EnumDescriptors first, EnumDescriptors second, EnumDescriptors third)
    {
        descriptor1.text = first.ToString();
        descriptor2.text = second.ToString();
        descriptor3.text = third.ToString();
    }

    private void SetHobbyTexts()    // im so chopped. (sebin 08/01/25)
    {
        int _randInt = Random.Range(0, hobbysList.Count);
        string pickedHobby = hobbysList[_randInt];
        hobby1Text.text = pickedHobby;

        hobbysList.Remove(pickedHobby);

        _randInt = Random.Range(0, hobbysList.Count);
        pickedHobby = hobbysList[_randInt];
        hobby2Text.text = pickedHobby;
    }
    
// designated fortune for each descriptor. no time rn to randomize within descriptor-unique list (sebin 08/01/25). SLOP FROM THE HORSE'S ASS!!!!!!
    private void SetFortuneText(int mainDescriptor)
    {
        fortuneText.text = fortunesList[mainDescriptor];
    }
    private void SetLuckyNumberText(int mainDescriptor) 
    {
        luckyNumberText.text = luckyNumbersList[mainDescriptor];
    }
    private void SetWeakPointText(int mainDescriptor)
    {
        weakPointText.text = weakPointsList[mainDescriptor];
    }
}
