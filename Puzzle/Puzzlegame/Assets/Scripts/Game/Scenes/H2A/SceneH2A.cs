using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneH2A:Scenebase
{
    public override void Start()
    {
        EventManager.Instance.AddEventListening<InteractableUIBase>(GameEvent.H2A.SceneChange.Clicked, OnSceneChangeIconClicked);
    }
}
