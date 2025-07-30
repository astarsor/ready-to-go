using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptorsHolder : MonoBehaviour
{
    public Descriptors[] descriptors;
}

[System.Serializable]
public class Descriptors
{
    public EnumDescriptors enumDescriptors;
    [Range(0, 1)] public float value = 1f;
}
public enum EnumDescriptors
{
    honest,
    wise,
    jock,
    zen,
    romantic,
    playful,
    cool
}