using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door : InteractableUIBase
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        EventManager.Instance.CallBack<InteractableUIBase>(GameEvent.H4.SceneChange.Clicked, this);
    }
}
