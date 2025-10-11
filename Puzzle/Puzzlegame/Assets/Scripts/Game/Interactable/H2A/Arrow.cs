using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Arrow : InteractableUIBase
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        EventManager.Instance.CallBack<InteractableUIBase>(GameEvent.H2A.SceneChange.Clicked, this);
    }
}
