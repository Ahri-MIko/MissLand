using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneH3:Scenebase
{
    public override void Start()
    {
        EventManager.Instance.AddEventListening<InteractableUIBase>(GameEvent.H3.SceneChange.Clicked, OnSceneChangeIconClicked);
    }
}
