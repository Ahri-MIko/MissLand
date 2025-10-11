using System;
using UnityEngine;

[Serializable]
public class TransPair
{
    [Header("交互UI")]
    public InteractableUIBase InteractableUIBase;
    [Header("目标场景")]
    public Scenebase Scenebase;
}