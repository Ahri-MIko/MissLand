using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneH4:Scenebase
{
    public override void Start()
    {
        EventManager.Instance.AddEventListening<InteractableUIBase>(GameEvent.H4.SceneChange.Clicked, OnSceneChangeIconClicked);
    }
}
