using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultsCanvasManager : MonoBehaviour
{
    public TextMeshProUGUI mainHeadingText,
        descriptor1, descriptor2, descriptor3,
        luckyNumber,
        jobProspect,
        hobby1, hobby2,
        weakPoint;
    public List<string> mainHeadingsList;
    public List<string> luckyNumbersList;
    public List<string> jobProspectsList;
    public List<string> hobbysList;
    public List<string> weakPointsList;

    void Start()
    {

    }
}
